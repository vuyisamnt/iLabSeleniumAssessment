using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace iLabSeleniumAssessment.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver driver;

        static ExtentReports extent;

        private static ExtentTest featureName;
        private static ExtentTest scenario;


        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void InitialiseReport()
        {
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\VuyisaMntabeko\source\repos\iLabSeleniumAssessment\iLabSeleniumAssessment\ExtentReport\index.html");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status.ToString().Equals("Skipped"))
            {
                return;
            }
        }

        [AfterStep]
        public void InsertReportingSteps()
        {

            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Pass("Pass");
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Pass("Pass");
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Pass("Pass");
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
            }
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
        }
    }
}
