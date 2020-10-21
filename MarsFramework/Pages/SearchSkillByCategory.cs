﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MarsFramework.Pages
{

    internal class SearchSkillByCategory
    {

        public SearchSkillByCategory()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //MarsLogoButton the Join 
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Mars Logo')]")]
        private IWebElement MarsLogoButton { get; set; }

        //MarsLogoButton the Join 
        [FindsBy(How = How.XPath, Using = "//img[@src='/icons/mars-computer.png']")]
        private IWebElement ProgrammingTechButton { get; set; }

        //Click on all category 
        [FindsBy(How = How.XPath, Using = "//b[contains(.,'All Categories')]")]
        private IWebElement AllCategoryButton { get; set; }

        public void gotoHomePage()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//a[contains(.,'Mars Logo')]"), 2000);
            MarsLogoButton.Click();
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("(//h3[@class='mainpage-heading'])[1]"), 2000);
            ProgrammingTechButton.Click();
         //   Thread.Sleep(10000);
//            AllCategoryButton.Click();
        }

        public bool isCategoriesPresent()
        {

            Thread.Sleep(2000);
            int count = GlobalDefinitions.driver.FindElements(By.XPath("//*[@id='service - search - section']/div[3]/div/section/div/div[1]/div[1]/div")).Count();
            Console.WriteLine("count:: " + count);
            for (int i=1; i< count; i++)
            {
                String xpath = string.Format("(//a[@class='item category'])[{0}]", i);
                string category = GlobalDefinitions.driver.FindElement(By.XPath(xpath)).Text;
                Console.WriteLine("Category:: "+category);
                if(category == null)
                {
                    return false;
                }
            }
            return true;
        }


    }
}
