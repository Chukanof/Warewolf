﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.2.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Warewolf.Tools.Specs.Toolbox.Database.SqlServer
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class SqlServerConnectorFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "SqlServerConnector.feature"
#line hidden
        
        public virtual Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return this._testContext;
            }
            set
            {
                this._testContext = value;
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SqlServerConnector", "    In order to manage my database services\r\n\r\n    As a Warewolf User\r\n\r\n    I wa" +
                    "nt to be shown the database service setup", ProgrammingLanguage.CSharp, new string[] {
                        "Database"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "SqlServerConnector")))
            {
                global::Warewolf.Tools.Specs.Toolbox.Database.SqlServer.SqlServerConnectorFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(TestContext);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Passing Timeouts to SQL Server")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlServerConnector")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Database")]
        public virtual void PassingTimeoutsToSQLServer()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Passing Timeouts to SQL Server", ((string[])(null)));
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
    testRunner.Given("I have a workflow \"Test Sql With Timeouts\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input Data or[[Variable]]",
                        "Parameter",
                        "Empty is Null"});
#line 11
 testRunner.And("\"Test Sql With Timeouts\" contains \"TestSqlExecutesWithTimeouts\" from server \"loca" +
                    "lhost\" with mapping as", ((string)(null)), table1, "And ");
#line 13
 testRunner.When("\"Test Sql With Timeouts\" is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
    testRunner.Then("the workflow containing the Sql Server connector has \"An\" execution error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table2.AddRow(new string[] {
                        ""});
#line 16
    testRunner.And("The Sql Server step \"TestSqlExecutesWithTimeouts\" in Workflow \"Test Sql With Time" +
                    "outs\" debug outputs appear as", ((string)(null)), table2, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Opening Saved workflow with SQL Server tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlServerConnector")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Database")]
        public virtual void OpeningSavedWorkflowWithSQLServerTool()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Opening Saved workflow with SQL Server tool", ((string[])(null)));
#line 20
this.ScenarioSetup(scenarioInfo);
#line 21
   testRunner.Given("I open workflow with database connector", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 23
    testRunner.And("Sql Server Source is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
    testRunner.And("Sql Server Source is \"testingDBSrc\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.And("Sql Server Action is \"dbo.Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("Sql Server Inputs Are Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input",
                        "Value",
                        "Empty is Null"});
            table3.AddRow(new string[] {
                        "Prefix",
                        "[[Prefix]]",
                        "false"});
#line 28
    testRunner.And("Sql Server Inputs appear as", ((string)(null)), table3, "And ");
#line 31
 testRunner.And("Validate Sql Server is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table4.AddRow(new string[] {
                        "CountryID",
                        "[[dbo_Pr_CitiesGetCountries().CountryID]]"});
            table4.AddRow(new string[] {
                        "Description",
                        "[[dbo_Pr_CitiesGetCountries().Description]]"});
#line 32
    testRunner.Then("Sql Server Outputs appear as", ((string)(null)), table4, "Then ");
#line 36
 testRunner.And("Sql Server Recordset Name equals \"dbo_Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Change SQL Server Source on Existing tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlServerConnector")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Database")]
        public virtual void ChangeSQLServerSourceOnExistingTool()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Change SQL Server Source on Existing tool", ((string[])(null)));
#line 38
this.ScenarioSetup(scenarioInfo);
#line 39
    testRunner.Given("I open workflow with database connector", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 41
    testRunner.And("Sql Server Source is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
    testRunner.And("Sql Server Source is \"testingDBSrc\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.And("Sql Server Action is \"dbo.Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
 testRunner.And("Sql Server Inputs Are Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input",
                        "Value",
                        "Empty is Null"});
            table5.AddRow(new string[] {
                        "Prefix",
                        "[[Prefix]]",
                        "false"});
#line 46
    testRunner.And("Sql Server Inputs appear as", ((string)(null)), table5, "And ");
#line 49
 testRunner.And("Validate Sql Server is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table6.AddRow(new string[] {
                        "CountryID",
                        "[[dbo_Pr_CitiesGetCountries().CountryID]]"});
            table6.AddRow(new string[] {
                        "Description",
                        "[[dbo_Pr_CitiesGetCountries().Description]]"});
#line 50
    testRunner.Then("Sql Server Outputs appear as", ((string)(null)), table6, "Then ");
#line 54
 testRunner.And("Sql Server Recordset Name equals \"dbo_Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.When("Source is changed from to \"GreenPoint\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 56
 testRunner.Then("Sql Server Action is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 57
    testRunner.And("Sql Server Inputs Are Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
    testRunner.And("Validate Sql Server is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Changing SQL Server Actions")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlServerConnector")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Database")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ChangingSqlServerFunctions")]
        public virtual void ChangingSQLServerActions()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Changing SQL Server Actions", new string[] {
                        "ChangingSqlServerFunctions"});
#line 61
this.ScenarioSetup(scenarioInfo);
#line 63
    testRunner.Given("I open workflow with database connector", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 64
    testRunner.And("Sql Server Source is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
    testRunner.And("Sql Server Source is \"testingDBSrc\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
 testRunner.And("Sql Server Action is \"dbo.Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.And("Sql Server Inputs Are Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input",
                        "Value",
                        "Empty is Null"});
            table7.AddRow(new string[] {
                        "Prefix",
                        "[[Prefix]]",
                        "false"});
#line 69
    testRunner.And("Sql Server Inputs appear as", ((string)(null)), table7, "And ");
#line 72
 testRunner.And("Validate Sql Server is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table8.AddRow(new string[] {
                        "CountryID",
                        "[[dbo_Pr_CitiesGetCountries().CountryID]]"});
            table8.AddRow(new string[] {
                        "Description",
                        "[[dbo_Pr_CitiesGetCountries().Description]]"});
#line 73
    testRunner.Then("Sql Server Outputs appear as", ((string)(null)), table8, "Then ");
#line 77
 testRunner.And("Sql Server Recordset Name equals \"dbo_Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
 testRunner.When("Action is changed from to \"dbo.ImportOrder\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 79
 testRunner.And("Sql Server Inputs Are Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input",
                        "Value",
                        "Empty is Null"});
            table9.AddRow(new string[] {
                        "ProductId",
                        "[[ProductId]]",
                        "false"});
#line 81
    testRunner.And("Sql Server Inputs appear as", ((string)(null)), table9, "And ");
#line 84
 testRunner.And("Validate Sql Server is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Change SQL Server Recordset Name")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlServerConnector")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Database")]
        public virtual void ChangeSQLServerRecordsetName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Change SQL Server Recordset Name", ((string[])(null)));
#line 86
this.ScenarioSetup(scenarioInfo);
#line 87
    testRunner.Given("I open workflow with database connector", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 89
    testRunner.And("Sql Server Source is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
    testRunner.And("Sql Server Source is \"testingDBSrc\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
 testRunner.And("Sql Server Action is \"dbo.Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
 testRunner.And("Sql Server Inputs Are Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input",
                        "Value",
                        "Empty is Null"});
            table10.AddRow(new string[] {
                        "Prefix",
                        "[[Prefix]]",
                        "false"});
#line 94
    testRunner.And("Sql Server Inputs appear as", ((string)(null)), table10, "And ");
#line 97
 testRunner.And("Validate Sql Server is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table11.AddRow(new string[] {
                        "CountryID",
                        "[[dbo_Pr_CitiesGetCountries().CountryID]]"});
            table11.AddRow(new string[] {
                        "Description",
                        "[[dbo_Pr_CitiesGetCountries().Description]]"});
#line 98
    testRunner.Then("Sql Server Outputs appear as", ((string)(null)), table11, "Then ");
#line 102
 testRunner.And("Sql Server Recordset Name equals \"dbo_Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
 testRunner.When("Recordset Name is changed to \"Pr_Cities\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table12.AddRow(new string[] {
                        "CountryID",
                        "[[Pr_Cities().CountryID]]"});
            table12.AddRow(new string[] {
                        "Description",
                        "[[Pr_Cities().Description]]"});
#line 104
 testRunner.Then("Sql Server Outputs appear as", ((string)(null)), table12, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("No SQL Server Action to be loaded Error")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlServerConnector")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Database")]
        public virtual void NoSQLServerActionToBeLoadedError()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("No SQL Server Action to be loaded Error", ((string[])(null)));
#line 109
this.ScenarioSetup(scenarioInfo);
#line 111
    testRunner.Given("I have a workflow \"NoStoredProceedureToLoad\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input Data or[[Variable]]",
                        "Parameter",
                        "Empty is Null"});
#line 112
 testRunner.And("\"NoStoredProceedureToLoad\" contains \"Testing/SQL/NoSqlStoredProceedure\" from serv" +
                    "er \"localhost\" with mapping as", ((string)(null)), table13, "And ");
#line 114
 testRunner.When("\"NoStoredProceedureToLoad\" is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 115
    testRunner.Then("the workflow containing the Sql Server connector has \"An\" execution error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table14.AddRow(new string[] {
                        "Error: The selected database does not contain actions to perform"});
#line 117
    testRunner.And("The Sql Server step \"Testing/SQL/NoSqlStoredProceedure\" in Workflow \"NoStoredProc" +
                    "eedureToLoad\" debug outputs appear as", ((string)(null)), table14, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Passing Null Input values to SQL Server")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlServerConnector")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Database")]
        public virtual void PassingNullInputValuesToSQLServer()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Passing Null Input values to SQL Server", ((string[])(null)));
#line 121
this.ScenarioSetup(scenarioInfo);
#line 122
    testRunner.Given("I have a workflow \"PassingNullInputValue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input Data or[[Variable]]",
                        "Parameter",
                        "Empty is Null"});
            table15.AddRow(new string[] {
                        "[[value]]",
                        "a",
                        "True"});
#line 123
 testRunner.And("\"PassingNullInputValue\" contains \"Acceptance Testing Resources/GreenPoint\" from s" +
                    "erver \"localhost\" with mapping as", ((string)(null)), table15, "And ");
#line 126
 testRunner.When("\"PassingNullInputValue\" is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 127
    testRunner.Then("the workflow containing the Sql Server connector has \"An\" execution error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table16.AddRow(new string[] {
                        "Error: Scalar value { value } is NULL"});
#line 129
    testRunner.And("The Sql Server step \"Acceptance Testing Resources/GreenPoint\" in Workflow \"Passin" +
                    "gNullInputValue\" debug outputs appear as", ((string)(null)), table16, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Mapped To Recordsets incorrect")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlServerConnector")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Database")]
        public virtual void MappedToRecordsetsIncorrect()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Mapped To Recordsets incorrect", ((string[])(null)));
#line 133
this.ScenarioSetup(scenarioInfo);
#line 135
    testRunner.Given("I have a workflow \"BadSqlParameterName\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input Data or[[Variable]]",
                        "Parameter",
                        "Empty is Null"});
            table17.AddRow(new string[] {
                        "",
                        "a",
                        "True"});
#line 136
 testRunner.And("\"BadSqlParameterName\" contains \"Acceptance Testing Resources/GreenPoint\" from ser" +
                    "ver \"localhost\" with mapping as", ((string)(null)), table17, "And ");
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table18.AddRow(new string[] {
                        "id",
                        "[[dbo_leon bob proc().id]]"});
            table18.AddRow(new string[] {
                        "some column Name",
                        "[[dbo_leon bob proc().some column Name]]"});
#line 139
 testRunner.And("And \"BadSqlParameterName\" contains \"Acceptance Testing Resources/GreenPoint\" from" +
                    " server \"localhost\" with Mapping To as", ((string)(null)), table18, "And ");
#line 143
 testRunner.When("\"BadSqlParameterName\" is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 144
    testRunner.Then("the workflow containing the Sql Server connector has \"An\" execution error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table19.AddRow(new string[] {
                        "Error: Sql Error: parse error"});
#line 146
    testRunner.And("The Sql Server step \"Acceptance Testing Resources/GreenPoint\" in Workflow \"BadSql" +
                    "ParameterName\" debug outputs appear as", ((string)(null)), table19, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Parameter not found in the collection")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlServerConnector")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Database")]
        public virtual void ParameterNotFoundInTheCollection()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Parameter not found in the collection", ((string[])(null)));
#line 152
this.ScenarioSetup(scenarioInfo);
#line 154
    testRunner.Given("I have a workflow \"BadMySqlParameterName\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table20 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input Data or[[Variable]]",
                        "Parameter",
                        "Empty is Null"});
            table20.AddRow(new string[] {
                        "",
                        "`p_startswith`",
                        "false"});
#line 155
 testRunner.And("\"BadMySqlParameterName\" contains \"Testing/MySql/MySqlParameters\" from server \"loc" +
                    "alhost\" with mapping as", ((string)(null)), table20, "And ");
#line 158
 testRunner.When("\"BadMySqlParameterName\" is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 159
    testRunner.Then("the workflow containing the Sql Server connector has \"An\" execution error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table21 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table21.AddRow(new string[] {
                        "Parameter \"p_startswith\" not found in the collection"});
#line 161
    testRunner.And("The Sql Server step \"Testing/MySql/MySqlParameters\" in Workflow \"BadMySqlParamete" +
                    "rName\" debug outputs appear as", ((string)(null)), table21, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Recordset has invalid character")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlServerConnector")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Database")]
        public virtual void RecordsetHasInvalidCharacter()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Recordset has invalid character", ((string[])(null)));
#line 166
this.ScenarioSetup(scenarioInfo);
#line 168
    testRunner.Given("I have a workflow \"MappingHasIncorrectCharacter\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table22 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input Data or[[Variable]]",
                        "Parameter",
                        "Empty is Null"});
            table22.AddRow(new string[] {
                        "1",
                        "charValue",
                        "True"});
#line 169
 testRunner.And("\"MappingHasIncorrectCharacter\" contains \"Acceptance Testing Resources/GreenPoint\"" +
                    " from server \"localhost\" with mapping as", ((string)(null)), table22, "And ");
#line 172
 testRunner.When("\"MappingHasIncorrectCharacter\" is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 173
    testRunner.Then("the workflow containing the Sql Server connector has \"An\" execution error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table23 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table23.AddRow(new string[] {
                        "[[dbo_ConvertTo, Int().result]] : Recordset name has invalid format"});
#line 175
    testRunner.And("The Sql Server step \"Acceptance Testing Resources/GreenPoint\" in Workflow \"Mappin" +
                    "gHasIncorrectCharacter\" debug outputs appear as", ((string)(null)), table23, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("SqlServer backward Compatiblity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlServerConnector")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Database")]
        public virtual void SqlServerBackwardCompatiblity()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("SqlServer backward Compatiblity", ((string[])(null)));
#line 180
this.ScenarioSetup(scenarioInfo);
#line 181
    testRunner.Given("I have a workflow \"DataMigration\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table24 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input to Service",
                        "From Variable",
                        "Output from Service",
                        "To Variable"});
            table24.AddRow(new string[] {
                        "[[ProductId]]",
                        "productId",
                        "[[dbo_GetCountries().CountryID]]",
                        "dbo_GetCountries().CountryID"});
            table24.AddRow(new string[] {
                        "",
                        "",
                        "[[dbo_GetCountries().Description]]",
                        "dbo_GetCountries().Description"});
#line 182
 testRunner.And("\"DataMigration\" contains \"DataCon\" from server \"localhost\" with mapping as", ((string)(null)), table24, "And ");
#line 186
 testRunner.When("\"DataMigration\" is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 187
    testRunner.Then("the workflow execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Execute Sql Server With Timeout")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlServerConnector")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Database")]
        public virtual void ExecuteSqlServerWithTimeout()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Execute Sql Server With Timeout", ((string[])(null)));
#line 189
this.ScenarioSetup(scenarioInfo);
#line 190
    testRunner.Given("I have workflow \"SqlWorkflowForTimeout\" with \"SqlServerActivity\" database connect" +
                    "or", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 191
    testRunner.And("Sql Server Source is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 192
    testRunner.And("I Select \"NewSqlServerSource\" as Server Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 193
    testRunner.And("I Select \"dbo.Pr_CitiesGetCountries\" as Server Action", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 194
    testRunner.And("Sql Server Inputs Are Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 195
 testRunner.And("Validate Sql Server is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 196
    testRunner.And("I click Sql Generate Outputs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 197
    testRunner.And("I click Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table25 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table25.AddRow(new string[] {
                        "CountryID",
                        "[[dbo_Pr_CitiesGetCountries().CountryID]]"});
            table25.AddRow(new string[] {
                        "Description",
                        "[[dbo_Pr_CitiesGetCountries().Description]]"});
#line 198
    testRunner.Then("Sql Server Outputs appear as", ((string)(null)), table25, "Then ");
#line 202
 testRunner.And("Sql Server Recordset Name equals \"dbo_Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 203
 testRunner.When("Workflow \"SqlWorkflowForTimeout\" containing dbTool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 204
    testRunner.And("the workflow execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
