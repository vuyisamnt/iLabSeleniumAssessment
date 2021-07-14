using iLabSeleniumAssessment.Models;
using iLabSeleniumAssessment.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace iLabSeleniumAssessment.StepDefinitions
{
    [Binding]
    public sealed class iLabSteps
    {
        private readonly ScenarioContext _scenarioContext;
        HomePage homePage = null;
        CareersPage careersPage = null;
        SouthAfricaPage southAfricaPage = null;
        FirstJobPage firstJobPage = null;


        IWebDriver webDriver = null;
        IWebDriver ffWebDriver = null;

        string selectedPageTitle;

        string browser = null;

        public iLabSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I launch iLab Website")]
        public void GivenILaunchILabWebsiteWith()
        {

            browser = ConfigurationManager.AppSettings["Browser"];

            if (browser == "Chrome")
            {
                var options = new ChromeOptions();

                options.AddArguments("start-maximized");

                webDriver = new ChromeDriver(options);

                webDriver.Navigate().GoToUrl(ConfigurationManager.AppSettings["iLabUrl"]);

                homePage = new HomePage(webDriver);
                careersPage = new CareersPage(webDriver);
                southAfricaPage = new SouthAfricaPage(webDriver);
                firstJobPage = new FirstJobPage(webDriver);


            }
            if (browser == "Firefox")
            {

                var options = new FirefoxOptions();

                options.AddArguments("start-maximized");

                options.BrowserExecutableLocation = @ConfigurationManager.AppSettings["FirefoxPath"];

                ffWebDriver = new FirefoxDriver(options);
                ffWebDriver.Manage().Window.Maximize();

                ffWebDriver.Navigate().GoToUrl(ConfigurationManager.AppSettings["iLabUrl"]);

                homePage = new HomePage(ffWebDriver);
                careersPage = new CareersPage(ffWebDriver);
                southAfricaPage = new SouthAfricaPage(ffWebDriver);
                firstJobPage = new FirstJobPage(ffWebDriver);
            }
        }

        [Then(@"I should see iLabs Home Page")]
        public void ThenIShouldSeeILabsHomePage()
        {
            homePage.IsILabsHomePageDisplayed();
        }

        [When(@"I click on Careers Link")]
        public void WhenIClickOnCareersLink()
        {
            homePage.ClickOnCareersLink();
        }

        [Then(@"I should see Careers Page")]
        public void ThenIShouldSeeCareersPage()
        {
            careersPage.IsILabsCareersPageDisplayed();
        }

        [When(@"I click on South Africa Link")]
        public void WhenIClickOnSouthAfricaLink()
        {
            careersPage.ClickOnSouthAfricaLink();
        }

        [Then(@"I should see South Africa Careers Page")]
        public void ThenIShouldSeeSouthAfricaCareersPage()
        {
            southAfricaPage.IsILabsSouthAfricaPageDisplayed();
        }

        [When(@"I click on first Job option")]
        public void WhenIClickOnFirstJobOption()
        {
            selectedPageTitle = southAfricaPage.GetFirstJobTitle();
            southAfricaPage.ClickOnFirstJobLink();
        }

        [Then(@"I should see first Job Page")]
        public void ThenIShouldSeeFirstJobPage()
        {
            firstJobPage.IsFirstJobPageDisplayed(selectedPageTitle);
        }

        [When(@"I click Apply Online dropdown")]
        public void ThenIClickApplyOnlineDropdown()
        {
            firstJobPage.ClickOnApplyOnline();
        }

        [When(@"I fill in required textbox")]
        public void WhenIFillInRequiredTextbox(Table table)
        {
            Applicant applicant = table.CreateInstance<Applicant>();
            firstJobPage.FillInApplicantInfo(applicant);
        }

        [When(@"I click on Send Application")]
        public void WhenIClickOnSendApplication()
        {
            firstJobPage.ClickSendApplication();
        }

        [Then(@"I should see uplaod File Error Message")]
        public void ThenIShouldSeeUplaodFileErrorMessage()
        {
            firstJobPage.SeeUploadFileErrorMessage();
        }

        [Then(@"I close the browser")]
        public void ThenICloseTheBrowser()
        {
            firstJobPage.CloseDriver();
        }
    }
}
