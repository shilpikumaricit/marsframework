using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MarsFramework.Global;
using MarsFramework.Utils;
using OpenQA.Selenium;

namespace MarsFramework.Pages
{
    class LanguagePage
    {

        private DropDownSelector dropDownSelector;

        private static IWebElement AddLanguageButton =>
            Global.GlobalDefinitions.driver.FindElement(By.XPath(XpathConstants.AddNewLanguageButton));
        private static IWebElement AddLanguageField
            => Global.GlobalDefinitions.driver.FindElement(By.XPath(XpathConstants.AddLangaugeField));

        private static IWebElement UpdateLanguageButton => Global.GlobalDefinitions.driver.FindElement(By.XPath(XpathConstants.UpdateLanguageXpath));

        public LanguagePage()
        {
            this.dropDownSelector = new DropDownSelector();
        }

        public void Addlanguage(string language, string selectLevel)
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("(//div[@class='ui teal button '][contains(.,'Add New')])[1]"), 10);
            AddLanguageButton.Click();
            AddLanguageField.SendKeys(language);
            this.dropDownSelector.getElementSelectedByName(XpathConstants.LanguageDropdownXPath, selectLevel);
            Global.GlobalDefinitions.driver.FindElement(By.XPath(XpathConstants.AddLanguageButton)).Click();
        }

        internal void EditLanguage(string actualLanguage, string newLanguage)
        {
            int recordsCount = Global.GlobalDefinitions.driver.FindElements(By.XPath(XpathConstants.LanguageTablePath)).Count;
            for (int i = 1; i <= recordsCount; i++)
            {
                IWebElement webElementEditButton = Global.GlobalDefinitions.driver.FindElement(By.XPath(string.Format(XpathConstants.EditButtonXPath, i)));
                var recordUserName = Global.GlobalDefinitions.driver.FindElement(By.XPath(string.Format(XpathConstants.EditLanguageButtonXPath, i))).Text;

                if (recordUserName == actualLanguage)
                {
                    webElementEditButton.Click();
                    IWebElement LanguageEditField = Global.GlobalDefinitions.driver.FindElement(By.XPath(string.Format(XpathConstants.EditLanguageFieldXPath, actualLanguage)));
                    LanguageEditField.Clear();
                    LanguageEditField.SendKeys(newLanguage);
                    UpdateLanguageButton.Click();
                    break;
                }
            }
        }

        public Boolean VerifyLanguage(string Language)
        {
            //Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Thread.Sleep(1000);
            int LanguageFieldRecordCount = Global.GlobalDefinitions.driver.FindElements(By.XPath(XpathConstants.LanguageTablePath)).Count;
            bool recordFound = false;
            for (int i = 1; i <= LanguageFieldRecordCount; i++)
            {
                var LanguageText = Global.GlobalDefinitions.driver.FindElement(By.XPath(string.Format(XpathConstants.LanguageFileTextXPath, i))).Text;

                if (LanguageText == Language)
                {
                    recordFound = true;
                    break;
                }
            }
            return recordFound;
        }

        internal void DeleteLanguage(string LanguageToDelete)
        {
            Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            int LanguageFieldRecordCount = Global.GlobalDefinitions.driver.FindElements(By.XPath(XpathConstants.LanguageTablePath)).Count;
            for (int i = 1; i <= LanguageFieldRecordCount; i++)
            {
                var LanguageFileText = Global.GlobalDefinitions.driver.FindElement(By.XPath(string.Format(XpathConstants.LanguageFileTextXPath, i))).Text;

                if (LanguageFileText == LanguageToDelete)
                {
                    IWebElement LanguageDeleteButton = Global.GlobalDefinitions.driver.FindElement(By.XPath(string.Format(XpathConstants.DeleteLanguageButtonXPath, i)));
                    LanguageDeleteButton.Click();
                    break;
                }
            }
        }
    }
}
