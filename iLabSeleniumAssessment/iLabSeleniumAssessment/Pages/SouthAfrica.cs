using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iLabSeleniumAssessment.Pages
{
    public class SouthAfricaPage
    {
        public IWebDriver WebDriver { get; }

        public SouthAfricaPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public IWebElement firstJobLink => WebDriver.FindElement(By.XPath("/html/body/section/div[2]/div/div/div/div[3]/div[2]/div/div/div/div/div/div[1]/div[1]/div[2]/div[1]"));

        public void ClickOnFirstJobLink()
        {
            firstJobLink.Click();
        }

        public bool IsILabsSouthAfricaPageDisplayed()
        {
            if (WebDriver.Title == "SOUTH AFRICA – iLAB")
                return true;
            else
                return false;
        }

        public string GetFirstJobTitle()
        {
            return firstJobLink.Text.Substring(0, 20);
        }


    }
}
