using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MarsFramework.Config;
using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MarsFramework.Pages
{
    internal class Description
    {

        [FindsBy(How = How.XPath, Using = "(//i[contains(@class,'outline write icon')])[1]")]
        private IWebElement DescriptionEditButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//textarea[contains(@maxlength,'600')]")]
        private IWebElement DescriptionTextField { get; set; }
        [FindsBy(How = How.XPath, Using = "(//button[contains(.,'Save')])[2]")]
        private IWebElement DescriptionSaveButton { get; set; }

        public Description()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        internal void AddDescription()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(MarsResource.ExcelPath, "Profile");

            //TODO 
            //GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("(//i[contains(@class,'outline write icon')])[1]"), 2000);
            Thread.Sleep(2000);
            DescriptionEditButton.Click();
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//textarea[contains(@maxlength,'600')]"), 20);
            DescriptionTextField.Clear();
            DescriptionTextField.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            DescriptionSaveButton.Click();
        }
        internal void ValidateAddDescription()
        {

        }
    }
}
