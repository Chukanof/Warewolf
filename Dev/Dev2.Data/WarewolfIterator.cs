using System;
using System.Linq;
using Dev2.Common;
using Dev2.Common.Interfaces;
using Dev2.Data.Util;
using Dev2.MathOperations;
using Warewolf.Resource.Errors;
using Warewolf.Storage;
using Dev2.Common.Interfaces.Diagnostics.Debug;
using System.Text;

namespace Dev2.Data
{
    public class WarewolfIterator : IWarewolfIterator
    {
        CommonFunctions.WarewolfEvalResult.WarewolfAtomListresult _listResult;
        CommonFunctions.WarewolfEvalResult.WarewolfAtomResult _scalarResult;
        readonly int _maxValue;
        int _currentValue;
        readonly FunctionEvaluatorOption _functionEvaluatorOption;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public WarewolfIterator(CommonFunctions.WarewolfEvalResult warewolfEvalResult)
        {
            SetupListResult(warewolfEvalResult);
            SetupScalarResult(warewolfEvalResult);
            SetupForWarewolfRecordSetResult(warewolfEvalResult);
            _maxValue = _listResult?.Item.Count(atom => atom != null) ?? 1;
            _currentValue = 0;
            _functionEvaluatorOption = FunctionEvaluatorOption.Dev2DateTimeFormat;
        }

        public WarewolfIterator(CommonFunctions.WarewolfEvalResult warewolfEvalResult, FunctionEvaluatorOption functionEvaluatorOption)
            : this(warewolfEvalResult)
        {
            _functionEvaluatorOption = functionEvaluatorOption;
        }

        void SetupForWarewolfRecordSetResult(CommonFunctions.WarewolfEvalResult warewolfEvalResult)
        {
            if (warewolfEvalResult.IsWarewolfRecordSetResult && warewolfEvalResult is CommonFunctions.WarewolfEvalResult.WarewolfRecordSetResult listResult)
            {
                var stringValue = "";
                foreach (var item in listResult.Item.Data)
                {
                    stringValue = SetupListResultItem(item);
                }
                _scalarResult = CommonFunctions.WarewolfEvalResult.NewWarewolfAtomResult(DataStorage.WarewolfAtom.NewDataString(stringValue)) as CommonFunctions.WarewolfEvalResult.WarewolfAtomResult;
            }

        }

        private static String SetupListResultItem(System.Collections.Generic.KeyValuePair<string, WarewolfParserInterop.WarewolfAtomList<DataStorage.WarewolfAtom>> item)
        {
            var stringValue = new StringBuilder();
            if (item.Key != EvaluationFunctions.PositionColumn)
            {
                var data = CommonFunctions.WarewolfEvalResult.NewWarewolfAtomListresult(item.Value) as CommonFunctions.WarewolfEvalResult.WarewolfAtomListresult;
                var warewolfEvalResultToString = ExecutionEnvironment.WarewolfEvalResultToString(data);
                if (string.IsNullOrEmpty(stringValue.ToString()))
                {
                    stringValue = new StringBuilder(warewolfEvalResultToString);
                }
                else
                {
                    stringValue.Append("," + warewolfEvalResultToString);
                }
            }

            return stringValue.ToString();
        }

        void SetupScalarResult(CommonFunctions.WarewolfEvalResult warewolfEvalResult)
        {
            if (warewolfEvalResult.IsWarewolfAtomResult)
            {
                _scalarResult = warewolfEvalResult as CommonFunctions.WarewolfEvalResult.WarewolfAtomResult;
            }
        }

        void SetupListResult(CommonFunctions.WarewolfEvalResult warewolfEvalResult)
        {
            if (warewolfEvalResult.IsWarewolfAtomListresult && warewolfEvalResult is CommonFunctions.WarewolfEvalResult.WarewolfAtomListresult warewolfAtomListresult)
            {
                warewolfAtomListresult.Item.ResetCurrentEnumerator();
                _listResult = warewolfAtomListresult;
            }

        }

        #region Implementation of IWarewolfIterator

        public int GetLength() => _maxValue;

        public string GetNextValue()
        {
            _currentValue++;
            if (_listResult != null)
            {
                var warewolfAtomToString = ExecutionEnvironment.WarewolfAtomToStringErrorIfNull(_listResult.Item.GetNextValue());
                warewolfAtomToString = DoCalcution(warewolfAtomToString);
                return warewolfAtomToString;
            }
            return _scalarResult != null ? DoCalcution(ExecutionEnvironment.WarewolfAtomToStringErrorIfNull(_scalarResult.Item)) : null;
        }

        string DoCalcution(string warewolfAtomToString)
        {
            if (warewolfAtomToString == null)
            {
                return null;
            }
            var isCalcEvaluation = DataListUtil.IsCalcEvaluation(warewolfAtomToString, out string cleanExpression);

            if (isCalcEvaluation)
            {
                var functionEvaluator = new FunctionEvaluator(_functionEvaluatorOption);
                var tryEvaluateFunction = functionEvaluator.TryEvaluateFunction(cleanExpression, out string eval, out string error);
                warewolfAtomToString = eval;
                if (eval == cleanExpression.Replace("\"", "") && cleanExpression.Contains("\""))
                {
                    TryEvalAsFunction(ref warewolfAtomToString, cleanExpression, functionEvaluator, ref error);
                }
                if (!tryEvaluateFunction)
                {
                    if (error == ErrorResource.IncorrectOperandType)
                    {
                        error += string.Format("Unable to calculate: '{0}'. Try rewriting the expression.", cleanExpression);
                    }

                    throw new Exception(error);
                }
            }
            return warewolfAtomToString;
        }

        private static void TryEvalAsFunction(ref string warewolfAtomToString, string cleanExpression, FunctionEvaluator functionEvaluator, ref string error)
        {
            try
            {
                var b = functionEvaluator.TryEvaluateFunction(cleanExpression.Replace("\"", ""), out string eval2, out error);
                if (b)
                {
                    warewolfAtomToString = eval2;

                }
            }
            catch (Exception err)
            {

                Dev2Logger.Warn(err, "Warewolf Warn");
            }
        }

        public bool HasMoreData() => _currentValue <= _maxValue - 1;

        #endregion
    }
}