﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Warewolf.AcceptanceTesting.DatabaseSource.OracleSqlSource
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class NewOracleDatabaseSourceFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "OracleSource.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "New Oracle Database Source", "\tIn order to avoid silly mistakes\r\n\tAs a math idiot\r\n\tI want to be told the sum o" +
                    "f two numbers", ProgrammingLanguage.CSharp, new string[] {
                        "OracleSource"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "New Oracle Database Source")))
            {
                Warewolf.AcceptanceTesting.DatabaseSource.OracleSqlSource.NewOracleDatabaseSourceFeature.FeatureSetup(null);
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
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Creating New DB Source as User Auth")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "New Oracle Database Source")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("OracleSource")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("OracleSource")]
        public virtual void CreatingNewDBSourceAsUserAuth()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Creating New DB Source as User Auth", new string[] {
                        "OracleSource"});
#line 26
this.ScenarioSetup(scenarioInfo);
#line 27
testRunner.Given("I open New database Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
   testRunner.Then("\"New Database Source\" tab is Opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
   testRunner.And("Title is \"New Database Source\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
   testRunner.And("Type options has \"Microsoft SQL Server\" as the default", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
   testRunner.And("I select type \"Oracle Database\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
   testRunner.Then("Authentication type \"Windows\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 33
   testRunner.And("I Select Authentication Type as \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
   testRunner.And("Username field is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
   testRunner.And("Password field is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
   testRunner.And("Database dropdown is \"Collapsed\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
   testRunner.When("I Type Server as \"Localhost\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Options"});
            table1.AddRow(new string[] {
                        ""});
#line 38
   testRunner.Then("the Intellisense contains these options", ((string)(null)), table1, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Options"});
            table2.AddRow(new string[] {
                        "Microsoft SQL Server"});
            table2.AddRow(new string[] {
                        "MySQL"});
            table2.AddRow(new string[] {
                        "Oracle Database"});
#line 41
   testRunner.And("Type options contains", ((string)(null)), table2, "And ");
#line 46
   testRunner.When("I type Username as \"testuser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 47
   testRunner.And("I type Password as \"test123\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
   testRunner.Then("database dropdown is \"Collapsed\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 49
   testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
   testRunner.When("Test Connecton is \"Successful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 51
   testRunner.Then("Database dropdown is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 52
   testRunner.Then("I select \"Dev2TestingDB\" as Database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 53
   testRunner.Then("\"Save\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 54
   testRunner.When("I save the source as \"SavedOracleDBSource\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
   testRunner.Then("the save dialog is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
   testRunner.Then("\"SavedOracleDBSource\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 57
   testRunner.And("title is \"SavedOracleDBSource\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
   testRunner.When("I type Server as \"RSA\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 59
   testRunner.Then("\"SavedOracleDBSource *\" is the tab Header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 60
   testRunner.And("title is \"SavedOracleDBSource\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Creating New DB Source as Windows Auth")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "New Oracle Database Source")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("OracleSource")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("OracleSource")]
        public virtual void CreatingNewDBSourceAsWindowsAuth()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Creating New DB Source as Windows Auth", new string[] {
                        "OracleSource"});
#line 63
this.ScenarioSetup(scenarioInfo);
#line 64
 testRunner.Given("I open New database Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 65
   testRunner.Then("\"New Database Source\" tab is Opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 66
   testRunner.And("Title is \"New Database Source\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
   testRunner.And("Type options has \"Microsoft SQL Server\" as the default", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
   testRunner.And("I Select Authentication Type as \"Windows\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
   testRunner.And("I select type \"Oracle Database\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
   testRunner.Then("Authentication type \"Windows\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Editing saved DB Source Remembers credentials")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "New Oracle Database Source")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("OracleSource")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("OracleSource")]
        public virtual void EditingSavedDBSourceRemembersCredentials()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Editing saved DB Source Remembers credentials", new string[] {
                        "OracleSource"});
#line 73
this.ScenarioSetup(scenarioInfo);
#line 74
testRunner.Given("I open \"Database Source - testOracle\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 75
 testRunner.And("type option has \"Oracle Database\" selected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
    testRunner.And("Server as \"localhost\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
    testRunner.And("Authentication Type is selected as \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
    testRunner.And("Username field is \"testuser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
    testRunner.And("Password field is \"******\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
 testRunner.And("Database \"Dev2TestingDB\" is selected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
    testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
 testRunner.When("I Select Authentication Type as \"Windows\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 83
    testRunner.Then("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 84
    testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
    testRunner.And("Database dropdown is \"Collapsed\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
    testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
    testRunner.And("Test Connecton is \"Successful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
    testRunner.And("\"Save\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
    testRunner.And("Database dropdown is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
    testRunner.And("I select \"Dev2TestingDB2\" as Database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
    testRunner.And("\"Save\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Creating New DB Source with invalid server")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "New Oracle Database Source")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("OracleSource")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("OracleSource")]
        public virtual void CreatingNewDBSourceWithInvalidServer()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Creating New DB Source with invalid server", new string[] {
                        "OracleSource"});
#line 95
this.ScenarioSetup(scenarioInfo);
#line 96
testRunner.Given("I open New database Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 97
   testRunner.Then("\"New Database Source\" tab is Opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 98
   testRunner.And("Title is \"New Database Source\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
   testRunner.And("Type options has \"Microsoft SQL Server\" as the default", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
   testRunner.And("I select type \"Oracle Database\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
   testRunner.Then("Authentication type \"Windows\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 102
   testRunner.And("I Select Authentication Type as \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
   testRunner.And("Username field is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
   testRunner.And("Password field is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
   testRunner.And("Database dropdown is \"Collapsed\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 106
   testRunner.When("I Type Server as \"Something that doesnt exst\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 107
   testRunner.And("Test Connecton is \"Unsuccessful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
