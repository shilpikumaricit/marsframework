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
    internal class ChangePassword
    {

        [FindsBy(How = How.XPath, Using = "//span[@tabindex='0']")]
        private IWebElement ClickOnGreeting { get; set; }

        //Change password link
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Change Password')]")]
        private IWebElement ChangePasswordLink { get; set; }

        //Current password field
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Current Password']")]
        private IWebElement CurrentPasswordField { get; set; }

        //New password field
        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'newPassword')]")]
        private IWebElement NewPasswordField { get; set; }


        //Confirm password field
        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'confirmPassword')]")]
        private IWebElement ConfirmPasswordField { get; set; }

        //Confirm password field
        [FindsBy(How = How.XPath, Using = "//button[@type='button'][contains(.,'Save')]")]
        private IWebElement SaveButton { get; set; }

        public ChangePassword()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        internal void UpdatePassword()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(MarsResource.ExcelPath, "SignIn");
            Thread.Sleep(5000);
            ClickOnGreeting.Click();
            Thread.Sleep(1000);
            ChangePasswordLink.Click();
            CurrentPasswordField.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Current Password"));
            NewPasswordField.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "New Password"));
            ConfirmPasswordField.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Confirm Password"));
            SaveButton.Click();
        }
        internal void ValidateAddDescription()
        {

        }
    }
}
