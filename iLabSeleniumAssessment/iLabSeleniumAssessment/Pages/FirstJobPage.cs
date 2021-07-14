using iLabSeleniumAssessment.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iLabSeleniumAssessment.Pages
{
    public class FirstJobPage
    {
        public IWebDriver WebDriver { get; }

        public FirstJobPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }


        public IWebElement firstJobLink => WebDriver.FindElement(By.XPath(ConfigurationManager.AppSettings["FirstLinkOption"]));
        public IWebElement applyOnline => WebDriver.FindElement(By.XPath(ConfigurationManager.AppSettings["ApplyOnline"]));
        public IWebElement applicantName => WebDriver.FindElement(By.Id(ConfigurationManager.AppSettings["ApplicantName"]));
        public IWebElement applicantEmail => WebDriver.FindElement(By.Id(ConfigurationManager.AppSettings["ApplicantEmail"]));
        public IWebElement applicantPhone => WebDriver.FindElement(By.Id(ConfigurationManager.AppSettings["ApplicantPhone"]));
        public IWebElement sendApplication => WebDriver.FindElement(By.Id(ConfigurationManager.AppSettings["SendApplication"]));
        public IWebElement uploadFileErrorMessage => WebDriver.FindElement(By.XPath(ConfigurationManager.AppSettings["UploadFileErrorMessage"]));


        public bool IsFirstJobPageDisplayed(string selectedPageTitle)
        {
            if (WebDriver.Title.ToString().Replace("–", "").Contains(selectedPageTitle.Replace("-", "")))
                return true;
            else
                return false;
        }

        public void ClickOnApplyOnline()
        {
            applyOnline.Click();
        }

        public void ClickSendApplication()
        {
            sendApplication.Click();
        }



        public void FillInApplicantInfo(Applicant applicant)
        {
            applicantName.SendKeys(applicant.Name);
            applicantEmail.SendKeys(applicant.Email_Address);
            applicantPhone.SendKeys(GeneratePhoneNumber());


        }

        private string GeneratePhoneNumber()
        {
            Random random = new Random();

            StringBuilder telNo = new StringBuilder(12);
            int number;

            telNo = telNo.Append("0");

            for (int i = 0; i < 1; i++)
            {
                number = random.Next(7, 8);
                telNo = telNo.Append(number.ToString());
            }
            for (int i = 0; i < 1; i++)
            {
                number = random.Next(2, 5);
                telNo = telNo.Append(number.ToString());
            }

            telNo = telNo.Append(" ");
            number = random.Next(0, 999);
            telNo = telNo.Append(String.Format("{0:D3}", number));
            telNo = telNo.Append(" ");
            number = random.Next(0, 10000);
            telNo = telNo.Append(String.Format("{0:D4}", number));

            return telNo.ToString();
        }

        public bool SeeUploadFileErrorMessage()
        {
            if (uploadFileErrorMessage.Text == ConfigurationManager.AppSettings["ErrorMessage"])
                return true;
            else
                return false;
        }

        public void CloseDriver()
        {
            WebDriver.Close();
            WebDriver.Dispose();
        }
    }
}
