using System;
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
        
        /* verifying the data is added edited and remove successfully
         * 
         */
        internal bool Verify()
        { 
            bool recordFound = false;
            GlobalDefinitions.ExcelLib.PopulateInCollection(MarsResource.ManageListingsExcelPath, "ManageListings");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//a[contains(.,'Manage Listings')]"), 10);
            manageListingsLink.Click();
            IWebElement WebElement = GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table"), 10);
           
            if(WebElement == null)
            {
                return recordFound;
            }
            int ManageListingCount = GlobalDefinitions.driver.FindElements(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table")).Count;
            
            for (int i = 1; i <= ManageListingCount; i++)
            {
                string Category = string.Format("(//td[contains(.,'{0}')])[1]", GlobalDefinitions.ExcelLib.ReadData(2, "Category"));
                if (GlobalDefinitions.driver.FindElement(By.XPath(Category)).Text == 
                    GlobalDefinitions.ExcelLib.ReadData(2, "Category"))
                {
                    recordFound = true;
                    break;
                }
            }
            return recordFound;
        }

        //Manage listing Table XPath
        [FindsBy(How = How.XPath, Using = "//*[@id='listing - management - section']/div[2]/div[1]/div[1]/table/")]
        private IWebElement ManageListingTable { get; set; }

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
        {//clicking on managelistinglink
            manageListingsLink.Click();

        }

        internal void EditListing()
        {//papulating the data from excelsheet
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//a[contains(.,'Manage Listings')]"), 10);
            manageListingsLink.Click();
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("(//i[@class='outline write icon'])[1]"), 10);
            //click on edit button
            edit.Click();
            ShareSkill shareSkill = new ShareSkill();
            shareSkill.EditShareSkill();
        }

        internal void DeleteListing()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//a[contains(.,'Manage Listings')]"), 10);
            manageListingsLink.Click();
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("(//i[@class='remove icon'])[1]"), 10);
            //click on delete button
            delete.Click();
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//button[contains(.,'Yes')]"), 20);
            clickActionsButton.Click();
        }

    }
}
