using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Dev2.Activities;
using Dev2.Activities.Debug;
using Dev2.Activities.SelectAndApply;
using Dev2.Common;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.Diagnostics.Debug;
using Dev2.Communication;
using Dev2.Data.Decisions.Operations;
using Dev2.Data.Util;
using Dev2.DataList;
using Dev2.DataList.Contract;
using Dev2.Diagnostics;
using Dev2.Diagnostics.Debug;
using Dev2.DynamicServices.Objects;
using Dev2.Interfaces;
using Dev2.Runtime.ESB.WF;
using Dev2.Runtime.Execution;
using Dev2.Runtime.Hosting;
using Dev2.Runtime.Security;
using Dev2.Runtime.ServiceModel.Data;
using Dev2.Services.Security;
using Dev2.Workspaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Unlimited.Applications.BusinessDesignStudio.Activities;
using Warewolf.Security.Encryption;
using Warewolf.Storage;
// ReSharper disable ParameterTypeCanBeEnumerable.Local

// ReSharper disable CyclomaticComplexity

namespace Dev2.Runtime.ESB.Execution
{
    public class ServiceTestExecutionContainer : EsbExecutionContainer
    {
        private readonly EsbExecuteRequest _request;

        public ServiceTestExecutionContainer(ServiceAction sa, IDSFDataObject dataObj, IWorkspace theWorkspace, IEsbChannel esbChannel, EsbExecuteRequest request)
            : base(sa, dataObj, theWorkspace, esbChannel)
        {
            _request = request;
        }

        /// <summary>
        /// Executes the specified errors.
        /// </summary>
        /// <param name="errors">The errors.</param>
        /// <param name="update"></param>
        /// <returns></returns>
        public override Guid Execute(out ErrorResultTO errors, int update)
        {

            errors = new ErrorResultTO();
            // WorkflowApplicationFactory wfFactor = new WorkflowApplicationFactory();
            Guid result = GlobalConstants.NullDataListID;


            Dev2Logger.Debug("Entered Wf Container");

            // Set Service Name
            DataObject.ServiceName = ServiceAction.ServiceName;

            // Set server ID, only if not set yet - original server;
            if (DataObject.ServerID == Guid.Empty)
                DataObject.ServerID = HostSecurityProvider.Instance.ServerID;

            // Set resource ID, only if not set yet - original resource;
            if (DataObject.ResourceID == Guid.Empty && ServiceAction?.Service != null)
                DataObject.ResourceID = ServiceAction.Service.ID;


            // Travis : Now set Data List
            DataObject.DataList = ServiceAction.DataListSpecification;
            // Set original instance ID, only if not set yet - original resource;
            if (DataObject.OriginalInstanceID == Guid.Empty)
                DataObject.OriginalInstanceID = DataObject.DataListID;
            Dev2Logger.Info($"Started Execution for Service Name:{DataObject.ServiceName} Resource Id:{DataObject.ResourceID} Mode:{(DataObject.IsDebug ? "Debug" : "Execute")}");
            //Set execution origin
            if (!string.IsNullOrWhiteSpace(DataObject.ParentServiceName))
            {
                DataObject.ExecutionOrigin = ExecutionOrigin.Workflow;
                DataObject.ExecutionOriginDescription = DataObject.ParentServiceName;
            }
            else if (DataObject.IsDebug)
            {
                DataObject.ExecutionOrigin = ExecutionOrigin.Debug;
            }
            else
            {
                DataObject.ExecutionOrigin = ExecutionOrigin.External;
            }


            ErrorResultTO to = errors;
            var serviceTestModelTo = TestCatalog.Instance.FetchTest(DataObject.ResourceID, DataObject.TestName);
            if (serviceTestModelTo == null)
            {
                TestCatalog.Instance.Load();
                serviceTestModelTo = TestCatalog.Instance.FetchTest(DataObject.ResourceID, DataObject.TestName);
            }
            if (serviceTestModelTo == null)
            {

                Dev2JsonSerializer serializer = new Dev2JsonSerializer();
                var testRunResult = new TestRunResult
                {
                    TestName = DataObject.TestName,
                    RunTestResult = RunResult.TestInvalid
                };
                Dev2Logger.Error($"Test {DataObject.TestName} for Resource {DataObject.ServiceName} ID {DataObject.ResourceID}");
                testRunResult.Message = $"Test {DataObject.TestName} for Resource {DataObject.ServiceName} ID {DataObject.ResourceID}";
                _request.ExecuteResult = serializer.SerializeToBuilder(testRunResult);
                return Guid.NewGuid();
            }
            if (serviceTestModelTo.Enabled)
            {
                if (serviceTestModelTo.AuthenticationType == AuthenticationType.User)
                {
                    Impersonator impersonator = new Impersonator();
                    var userName = serviceTestModelTo.UserName;
                    var domain = "";
                    if (userName.Contains("\\"))
                    {
                        var slashIndex = userName.IndexOf("\\", StringComparison.InvariantCultureIgnoreCase);
                        domain = userName.Substring(0, slashIndex);
                        userName = userName.Substring(slashIndex + 1);
                    }
                    else if (userName.Contains("@"))
                    {
                        var atIndex = userName.IndexOf("@", StringComparison.InvariantCultureIgnoreCase);
                        userName = userName.Substring(0, atIndex);
                        domain = userName.Substring(atIndex + 1);
                    }
                    var hasImpersonated = impersonator.Impersonate(userName, domain, DpapiWrapper.DecryptIfEncrypted(serviceTestModelTo.Password));
                    if (!hasImpersonated)
                    {
                        DataObject.Environment.AllErrors.Add("Unauthorized to execute this resource.");
                        DataObject.StopExecution = true;
                    }
                }
                else if (serviceTestModelTo.AuthenticationType == AuthenticationType.Public)
                {
                    Thread.CurrentPrincipal = GlobalConstants.GenericPrincipal;
                }
                var userPrinciple = Thread.CurrentPrincipal;
                Common.Utilities.PerformActionInsideImpersonatedContext(userPrinciple, () =>
                {
                    result = ExecuteWf(to, serviceTestModelTo);
                });
                foreach (var err in DataObject.Environment.Errors)
                {
                    errors.AddError(err, true);
                }
                foreach (var err in DataObject.Environment.AllErrors)
                {
                    errors.AddError(err, true);
                }

                Dev2Logger.Info($"Completed Execution for Service Name:{DataObject.ServiceName} Resource Id: {DataObject.ResourceID} Mode:{(DataObject.IsDebug ? "Debug" : "Execute")}");
            }
            return result;
        }

        public override bool CanExecute(Guid resourceId, IDSFDataObject dataObject, AuthorizationContext authorizationContext)
        {
            return true;
        }

        private static void AddRecordsetsInputs(IEnumerable<IServiceTestInput> recSets, IExecutionEnvironment environment)
        {
            if (recSets != null)
            {
                var groupedRecsets = recSets.GroupBy(item => DataListUtil.ExtractRecordsetNameFromValue(item.Variable));
                foreach (var groupedRecset in groupedRecsets)
                {
                    var dataListItems = groupedRecset.GroupBy(item => DataListUtil.ExtractIndexRegionFromRecordset(item.Variable));
                    foreach (var dataListItem in dataListItems)
                    {
                        List<IServiceTestInput> recSetsToAssign = new List<IServiceTestInput>();
                        var empty = true;
                        foreach (var listItem in dataListItem)
                        {
                            if (!string.IsNullOrEmpty(listItem.Value))
                            {
                                empty = false;
                            }
                            recSetsToAssign.Add(listItem);
                        }
                        if (!empty)
                        {
                            foreach (var serviceTestInput in recSetsToAssign)
                            {
                                if (!serviceTestInput.EmptyIsNull || !string.IsNullOrEmpty(serviceTestInput.Value))
                                {
                                    environment.Assign(DataListUtil.AddBracketsToValueIfNotExist(serviceTestInput.Variable), serviceTestInput.Value, 0);
                                }
                            }
                        }
                    }
                }
            }
        }

        Guid ExecuteWf(ErrorResultTO to, IServiceTestModelTO test)
        {
            Guid result = new Guid();
            var wfappUtils = new WfApplicationUtils();
            ErrorResultTO invokeErrors = new ErrorResultTO();
            var resourceId = DataObject.ResourceID;
            if (test?.Inputs != null)
            {
                AddRecordsetsInputs(test.Inputs.Where(input => DataListUtil.IsValueRecordset(input.Variable) && !input.Variable.Contains("@")), DataObject.Environment);
                foreach (var input in test.Inputs)
                {
                    var variable = DataListUtil.AddBracketsToValueIfNotExist(input.Variable);
                    var value = input.Value;
                    if (variable.StartsWith("[[@"))
                    {
                        var jContainer = JsonConvert.DeserializeObject(value) as JObject;
                        DataObject.Environment.AddToJsonObjects(variable, jContainer);
                    }
                    else if (!DataListUtil.IsValueRecordset(input.Variable))
                    {
                        if (!input.EmptyIsNull || !string.IsNullOrEmpty(value))
                        {
                            DataObject.Environment.Assign(variable, value, 0);
                        }
                    }
                }
            }
            Dev2JsonSerializer serializer = new Dev2JsonSerializer();
            try
            {
                IExecutionToken exeToken = new ExecutionToken { IsUserCanceled = false };
                DataObject.ExecutionToken = exeToken;

                if (DataObject.IsDebugMode())
                {
                    var debugState = wfappUtils.GetDebugState(DataObject, StateType.Start, DataObject.Environment.HasErrors(), DataObject.Environment.FetchErrors(), invokeErrors, DateTime.Now, true, false, false);
                    wfappUtils.WriteDebug(DataObject, debugState);
                }

                var testRunResult = Eval(resourceId, DataObject, test);

                if (DataObject.IsDebugMode())
                {
                    var debugState = wfappUtils.GetDebugState(DataObject, StateType.End, DataObject.Environment.HasErrors(), DataObject.Environment.FetchErrors(), invokeErrors, DataObject.StartTime, false, true, true);
                    DebugItem itemToAdd = new DebugItem();
                    if (test != null)
                    {
                        var msg = test.FailureMessage;
                        if (test.TestPassed)
                        {
                            msg = Warewolf.Resource.Messages.Messages.Test_PassedResult;
                        }
                        itemToAdd.AddRange(new DebugItemServiceTestStaticDataParams(msg,test.TestFailing).GetDebugItemResult());
                    }
                    debugState.AssertResultList.Add(itemToAdd);
                    wfappUtils.WriteDebug(DataObject, debugState);
                }
                if (testRunResult != null)
                {
                    if (test != null)
                        test.Result.DebugForTest = TestDebugMessageRepo.Instance.FetchDebugItems(resourceId, test.TestName);
                    _request.ExecuteResult = serializer.SerializeToBuilder(testRunResult);
                }
                result = DataObject.DataListID;
            }
            catch (InvalidWorkflowException iwe)
            {
                Dev2Logger.Error(iwe);
                var msg = iwe.Message;

                int start = msg.IndexOf("Flowchart ", StringComparison.Ordinal);
                to?.AddError(start > 0 ? GlobalConstants.NoStartNodeError : iwe.Message);
                var failureMessage = DataObject.Environment.FetchErrors();
                wfappUtils.DispatchDebugState(DataObject, StateType.End, DataObject.Environment.HasErrors(), failureMessage, out invokeErrors, DataObject.StartTime, false, true);

                // ReSharper disable once PossibleNullReferenceException
                test.TestFailing = false;
                test.TestPassed = false;
                test.TestPending = false;
                test.TestInvalid = true;
                test.LastRunDate = DateTime.Now;


                Common.Utilities.PerformActionInsideImpersonatedContext(Common.Utilities.ServerUser, () => { TestCatalog.Instance.SaveTest(resourceId, test); });

                var testRunResult = new TestRunResult { TestName = test.TestName };
                if (test.TestInvalid)
                {
                    testRunResult.RunTestResult = RunResult.TestInvalid;
                    testRunResult.Message = failureMessage;
                    Dev2Logger.Error($"Test {DataObject.TestName} for Resource {DataObject.ServiceName} ID {DataObject.ResourceID} marked invalid in exception for no start node");
                }
                testRunResult.DebugForTest = TestDebugMessageRepo.Instance.FetchDebugItems(resourceId, test.TestName);
                if (_request != null)
                    _request.ExecuteResult = serializer.SerializeToBuilder(testRunResult);
            }
            catch (Exception ex)
            {
                Dev2Logger.Error(ex);
                to.AddError(ex.Message);
                var failureMessage = DataObject.Environment.FetchErrors();
                wfappUtils.DispatchDebugState(DataObject, StateType.End, DataObject.Environment.HasErrors(), failureMessage, out invokeErrors, DataObject.StartTime, false, true);
                // ReSharper disable once PossibleNullReferenceException
                test.TestFailing = false;
                test.TestPassed = false;
                test.TestPending = false;
                test.TestInvalid = true;
                test.LastRunDate = DateTime.Now;


                Common.Utilities.PerformActionInsideImpersonatedContext(Common.Utilities.ServerUser, () => { TestCatalog.Instance.SaveTest(resourceId, test); });

                var testRunResult = new TestRunResult { TestName = test.TestName };
                if (test.TestInvalid)
                {
                    testRunResult.RunTestResult = RunResult.TestInvalid;
                    testRunResult.Message = ex.Message;
                    Dev2Logger.Error($"Test {DataObject.TestName} for Resource {DataObject.ServiceName} ID {DataObject.ResourceID} marked invalid in general exception");
                }
                testRunResult.DebugForTest = TestDebugMessageRepo.Instance.FetchDebugItems(resourceId, test.TestName);
                _request.ExecuteResult = serializer.SerializeToBuilder(testRunResult);
            }
            return result;
        }

        private IServiceTestModelTO Eval(Guid resourceId, IDSFDataObject dataObject, IServiceTestModelTO test)
        {
            Dev2Logger.Debug("Getting Resource to Execute");
            IDev2Activity resource = ResourceCatalog.Instance.Parse(TheWorkspace.ID, resourceId);
            Dev2JsonSerializer serializer = new Dev2JsonSerializer();
            var execPlan = serializer.SerializeToBuilder(resource);
            var clonedExecPlan = serializer.Deserialize<IDev2Activity>(execPlan);
            Dev2Logger.Debug("Got Resource to Execute");

            if (test != null)
            {
                var testPassed = true;
                var canExecute = true;
                var failureMessage = new StringBuilder();
                if (ServerAuthorizationService.Instance != null)
                {
                    var authorizationService = ServerAuthorizationService.Instance;
                    var hasView = authorizationService.IsAuthorized(AuthorizationContext.View, DataObject.ResourceID.ToString());
                    var hasExecute = authorizationService.IsAuthorized(AuthorizationContext.Execute, DataObject.ResourceID.ToString());
                    canExecute = hasExecute && hasView;
                }
                if (!canExecute)
                {
                    dataObject.Environment.AllErrors.Add("Unauthorized to execute this resource.");
                }
                else
                {
                    if (!dataObject.StopExecution)
                    {
                        dataObject.ServiceTest = test;
                        EvalInner(dataObject, clonedExecPlan, dataObject.ForEachUpdateValue, test.TestSteps);
                        if (!dataObject.StopExecution)
                        {
                            if (test.Outputs != null)
                            {
                                var dev2DecisionFactory = Dev2DecisionFactory.Instance();
                                var testRunResults = test.Outputs.SelectMany(output => GetTestRunResults(dataObject, output, dev2DecisionFactory)).ToList();
                                testPassed = testRunResults.All(result => result.RunTestResult == RunResult.TestPassed);
                                if (!testPassed)
                                {
                                    failureMessage = failureMessage.AppendLine(string.Join(Environment.NewLine,testRunResults.Select(result => result.Message).ToList()));
                                }
                            }
                        }
                    }
                }
                var fetchErrors = DataObject.Environment.FetchErrors();
                var hasErrors = DataObject.Environment.HasErrors();
                if (test.ErrorExpected)
                {
                    testPassed = hasErrors && testPassed && fetchErrors.ToLower().Contains(test.ErrorContainsText.ToLower());
                    if (!testPassed)
                    {
                        failureMessage.AppendLine(string.Format(Warewolf.Resource.Messages.Messages.Test_FailureMessage_Equals, test.ErrorContainsText, "", fetchErrors));
                    }
                }
                else if (test.NoErrorExpected)
                {
                    testPassed = !hasErrors && testPassed;
                    if (hasErrors)
                    {

                        failureMessage.AppendLine(fetchErrors);
                    }
                }
                if (test.TestSteps != null)
                {
                    var testStepPassed = true;
                    foreach (var serviceTestStep in test.TestSteps)
                    {
                        if (serviceTestStep.Type != StepType.Mock)
                        {
                            testStepPassed = serviceTestStep.Result?.RunTestResult == RunResult.TestPassed;
                        }
                        if (!testStepPassed)
                        {
                            break;
                        }
                    }

                    testPassed = testPassed && testStepPassed;
                    test.FailureMessage = failureMessage.AppendLine(string.Join("", test.TestSteps.Select(step => step.Result?.Message))).ToString();
                    test.TestFailing = !testPassed;
                    test.TestPassed = testPassed;
                    test.TestPending = false;
                    test.TestInvalid = test.TestSteps.Any(step => step.Result?.RunTestResult == RunResult.TestInvalid);
                }
                test.LastRunDate = DateTime.Now;

                var testRunResult = new TestRunResult { TestName = test.TestName };
                if (test.TestFailing)
                {
                    testRunResult.RunTestResult = RunResult.TestFailed;
                    testRunResult.Message = test.FailureMessage;
                }
                if (test.TestPassed)
                {
                    testRunResult.RunTestResult = RunResult.TestPassed;
                }
                if (test.TestInvalid)
                {
                    testRunResult.RunTestResult = RunResult.TestInvalid;
                }
                test.Result = testRunResult;
                Common.Utilities.PerformActionInsideImpersonatedContext(Common.Utilities.ServerUser, () => { TestCatalog.Instance.SaveTest(resourceId, test); });

                return test;
            }
            throw new Exception($"Test {dataObject.TestName} for Resource {dataObject.ServiceName} ID {resourceId}");
        }


        private IEnumerable<TestRunResult> GetTestRunResults(IDSFDataObject dataObject, IServiceTestOutput output, Dev2DecisionFactory factory)
        {
            var expressionType = output.AssertOp??string.Empty;
            IFindRecsetOptions opt = FindRecsetOptions.FindMatch(expressionType);
            var decisionType = DecisionDisplayHelper.GetValue(expressionType);

            if (decisionType == enDecisionType.IsError)
            {
                var hasErrors = dataObject.Environment.AllErrors.Count > 0;
                var testResult = new TestRunResult();
                if (hasErrors)
                {
                    testResult.RunTestResult = RunResult.TestPassed;
                }
                else
                {
                    testResult.RunTestResult = RunResult.TestFailed;
                    testResult.Message = new StringBuilder(testResult.Message).AppendLine("Failed").ToString();
                }
                return new[] { testResult };
            }
            if (decisionType == enDecisionType.IsNotError)
            {
                var noErrors = dataObject.Environment.AllErrors.Count == 0;
                var testResult = new TestRunResult();
                if (noErrors)
                {
                    testResult.RunTestResult = RunResult.TestPassed;
                }
                else
                {
                    testResult.RunTestResult = RunResult.TestFailed;
                    testResult.Message = new StringBuilder(testResult.Message).AppendLine("Failed").ToString();
                }
                return new[] { testResult };
            }
            var value = new List<DataStorage.WarewolfAtom> { DataStorage.WarewolfAtom.NewDataString(output.Value) };
            var from = new List<DataStorage.WarewolfAtom> { DataStorage.WarewolfAtom.NewDataString(output.From) };
            var to = new List<DataStorage.WarewolfAtom> { DataStorage.WarewolfAtom.NewDataString(output.To) };

            IList<TestRunResult> ret = new List<TestRunResult>();
            var iter = new WarewolfListIterator();
            var cols1 = dataObject.Environment.EvalAsList(DataListUtil.AddBracketsToValueIfNotExist(output.Variable), 0);
            var c1 = new WarewolfAtomIterator(cols1);
            var c2 = new WarewolfAtomIterator(value);
            var c3 = new WarewolfAtomIterator(@from);
            if (opt.ArgumentCount > 2)
            {
                c2 = new WarewolfAtomIterator(to);
            }
            iter.AddVariableToIterateOn(c1);
            iter.AddVariableToIterateOn(c2);
            iter.AddVariableToIterateOn(c3);
            while (iter.HasMoreData())
            {
                var assertResult = factory.FetchDecisionFunction(decisionType).Invoke(new[] { iter.FetchNextValue(c1), iter.FetchNextValue(c2), iter.FetchNextValue(c3) });
                var testResult = new TestRunResult();
                if (assertResult)
                {
                    testResult.RunTestResult = RunResult.TestPassed;
                }
                else
                {
                    testResult.RunTestResult = RunResult.TestFailed;
                    testResult.Message = new StringBuilder(testResult.Message).AppendLine("Failed").ToString();
                }
                output.Result = testResult;
                ret.Add(testResult);
            }
            return ret;
        }

        public override IDSFDataObject Execute(IDSFDataObject inputs, IDev2Activity activity)
        {
            return null;
        }

        static void EvalInner(IDSFDataObject dsfDataObject, IDev2Activity resource, int update, List<IServiceTestStep> testSteps)
        {
            if (resource == null)
            {
                throw new InvalidOperationException(GlobalConstants.NoStartNodeError);
            }
            WorkflowExecutionWatcher.HasAWorkflowBeenExecuted = true;
            resource = NextActivity(resource, testSteps);
            var next = resource.Execute(dsfDataObject, update);
            while (next != null)
            {
                if (!dsfDataObject.StopExecution)
                {
                    next = NextActivity(next, testSteps);
                    next = next.Execute(dsfDataObject, update);
                    if (dsfDataObject.Environment.Errors.Count > 0)
                    {
                        foreach (var e in dsfDataObject.Environment.Errors)
                        {
                            dsfDataObject.Environment.AllErrors.Add(e);
                        }

                    }
                }
                else
                {
                    break;
                }
            }
        }

        private static IDev2Activity NextActivity(IDev2Activity resource, List<IServiceTestStep> testSteps)
        {
            var foundTestStep = testSteps?.FirstOrDefault(step => resource != null && step.UniqueId.ToString() == resource.UniqueID);
            if (foundTestStep != null)
            {
                if (foundTestStep.ActivityType == typeof(DsfDecision).Name && foundTestStep.Type == StepType.Mock)
                {
                    var serviceTestOutput = foundTestStep.StepOutputs.FirstOrDefault(output => output.Variable == GlobalConstants.ArmResultText);
                    if (serviceTestOutput != null)
                    {
                        resource = new TestMockDecisionStep(resource as DsfDecision) { NameOfArmToReturn = serviceTestOutput.Value };
                    }
                }
                else if (foundTestStep.ActivityType == typeof(DsfSwitch).Name && foundTestStep.Type == StepType.Mock)
                {
                    var serviceTestOutput = foundTestStep.StepOutputs.FirstOrDefault(output => output.Variable == GlobalConstants.ArmResultText);
                    if (serviceTestOutput != null)
                    {
                        resource = new TestMockSwitchStep(resource as DsfSwitch) { ConditionToUse = serviceTestOutput.Value };
                    }
                }
                else if (foundTestStep.ActivityType == typeof(DsfSequenceActivity).Name)
                {
                    var sequenceActivity = resource as DsfSequenceActivity;
                    if (sequenceActivity != null)
                    {
                        var acts = sequenceActivity.Activities;
                        for (int index = 0; index < acts.Count; index++)
                        {
                            var activity = acts[index];
                            if (foundTestStep.Children != null)
                            {
                                var replacement = NextActivity(activity as IDev2Activity, foundTestStep.Children.ToList()) as Activity;
                                acts[index] = replacement;
                            }
                        }
                    }
                }
                else if (foundTestStep.ActivityType == typeof(DsfForEachActivity).Name)
                {
                    var forEach = resource as DsfForEachActivity;
                    if (forEach != null)
                    {
                        if (foundTestStep.Children != null)
                        {
                            var replacement = NextActivity(forEach.DataFunc.Handler as IDev2Activity, foundTestStep.Children.ToList()) as Activity;
                            forEach.DataFunc.Handler = replacement;
                        }
                    }
                }
                else if (foundTestStep.ActivityType == typeof(DsfSelectAndApplyActivity).Name)
                {
                    var forEach = resource as DsfSelectAndApplyActivity;
                    if (forEach != null)
                    {
                        if (foundTestStep.Children != null)
                        {
                            var replacement = NextActivity(forEach.ApplyActivityFunc.Handler as IDev2Activity, foundTestStep.Children.ToList()) as Activity;
                            forEach.ApplyActivityFunc.Handler = replacement;
                        }
                    }
                }
                else if (foundTestStep.Type == StepType.Mock)
                {
                    resource = new TestMockStep(resource, foundTestStep.StepOutputs.ToList());
                }
            }
            return resource;
        }

    }
}