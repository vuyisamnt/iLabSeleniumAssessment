using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iLabSeleniumAssessment.Pages
{
    public class CareersPage
    {
        public IWebDriver WebDriver { get; }

        public CareersPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public IWebElement southAfricaLink => WebDriver.FindElement(By.XPath("//a[@href ='/careers/south-africa/']"));

        //Methods
        public bool IsILabsCareersPageDisplayed()
        {
            if (WebDriver.Title == "CAREERS – iLAB")
                return true;
            else
                return false;
        }

        public void ClickOnSouthAfricaLink()
        {
            southAfricaLink.Click();
        }
    }
}
