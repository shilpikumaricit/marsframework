using MarsFramework.Config;
using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
            GlobalDefinitions.ExcelLib.PopulateInCollection(MarsResource.ManageListingsExcelPath, "ManageListings");
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Manage Listings')]")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='remove icon'])[1]")]
        private IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//button[contains(.,'Yes')]")]
        private IWebElement clickActionsButton { get; set; }

        internal void Listings()
        {
            manageListingsLink.Click();

        }

        internal void EditListing()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//a[contains(.,'Manage Listings')]"), 10);
            manageListingsLink.Click();
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("(//i[@class='outline write icon'])[1]"), 10);
            edit.Click();
            ShareSkill shareSkill = new ShareSkill();
            shareSkill.EditShareSkill();
        }

        internal void DeleteListing()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//a[contains(.,'Manage Listings')]"), 10);
            manageListingsLink.Click();
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("(//i[@class='remove icon'])[1]"), 10);
            delete.Click();
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//button[contains(.,'Yes')]"), 20);
            clickActionsButton.Click();
        }

        internal void VerifyListing()
        {
            delete.Click();
        }
    }
}
