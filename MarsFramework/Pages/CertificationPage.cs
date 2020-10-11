using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MarsFramework.Global;
using MarsFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MarsFramework.Pages
{
    class CertificationPage
    {

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Certifications')]")]
        private IWebElement CertificateTabButton { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='ui teal button '])[3]")]
        private IWebElement CertificateAddButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='certificationName']")]
        private IWebElement CertificateAwardField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='certificationFrom']")]
        private IWebElement CertificateAwardedFrom { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@name='certificationYear']")]
        private IWebElement CertificateAwardedInYear { get; set; }

        //Click on Availability Time option
        [FindsBy(How = How.XPath, Using = "//option[@value='2020']")]
        private IWebElement CertificateYearOpt { get; set; }

        //Click on Availability Time option
        [FindsBy(How = How.XPath, Using = "//input[@value='Add']")]
        private IWebElement CertificateSaveAdd { get; set; }

        public CertificationPage()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        public void AddCertificate(string awardField, string certificationFrom)
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//a[contains(.,'Certifications')]"), 10);
            CertificateTabButton.Click();
            CertificateAddButton.Click();
            CertificateAwardField.SendKeys(awardField);
            CertificateAwardedFrom.SendKeys(certificationFrom);
            CertificateAwardedInYear.Click();
            CertificateYearOpt.Click();
            CertificateSaveAdd.Click();
        }

        internal bool VerifyCertificationPage(string certificate)
        {
            Thread.Sleep(5000);
            int SkillFieldRecordCount = Global.GlobalDefinitions.driver.FindElements(By.XPath(XpathConstants.certificateTableXPath)).Count;
            bool recordFound = false;
            for (int i = 1; i <= SkillFieldRecordCount; i++)
            {
                var webElement = Global.GlobalDefinitions.driver.FindElement(By.XPath(string.Format(XpathConstants.certificateRowFieldValueXPath, i))).Text;

                if (webElement == certificate)
                {
                    recordFound = true;
                    break;
                }
            }
            return recordFound;
        }
    }
}
