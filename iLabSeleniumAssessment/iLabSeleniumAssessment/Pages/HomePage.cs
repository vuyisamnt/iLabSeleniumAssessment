using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iLabSeleniumAssessment.Pages
{
    public class HomePage
    {
        public IWebDriver WebDriver { get; }

        public HomePage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        //Page Elements

        public IWebElement careersLink => WebDriver.FindElement(By.Id("menu-item-1373"));

        //Methods
        public bool IsILabsHomePageDisplayed()
        {
            if (WebDriver.Title == "iLAB – Software Quality Assurance")
                return true;
            else
                return false;
        }

        public void ClickOnCareersLink()
        {
            careersLink.Click();
        }
    }
}
