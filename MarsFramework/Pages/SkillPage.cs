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
    class SkillPage
    {
        private DropDownSelector dropDownSelector;
        private static IWebElement ClickSkillTab =>
           Global.GlobalDefinitions.driver.FindElement(By.XPath(XpathConstants.SkillTab));
        private static IWebElement AddSkillNewButton =>
           Global.GlobalDefinitions.driver.FindElement(By.XPath(XpathConstants.SkillAddNewButton));
        private static IWebElement AddSkillField
            => Global.GlobalDefinitions.driver.FindElement(By.XPath(XpathConstants.AddSkillField));

        private static IWebElement EditskillButton => Global.GlobalDefinitions.driver.FindElement(By.XPath(XpathConstants.skillEditButton));
        private static IWebElement EditSkillButton => Global.GlobalDefinitions.driver.FindElement(By.XPath(XpathConstants.SkillUpdateFieldXPath));

        private static IWebElement UpdateSkillButton => Global.GlobalDefinitions.driver.FindElement(By.XPath(XpathConstants.SkillUpdateButton));
        private static IWebElement DeleteSkillButton => Global.GlobalDefinitions.driver.FindElement(By.XPath(XpathConstants.DeleteSkillButton));
        public SkillPage()
        {
            this.dropDownSelector = new DropDownSelector();
        }

        public void AddSkill(string Skill, string selectLevel)
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//a[contains(.,'Skills')]"), 10);
            ClickSkillTab.Click();
            AddSkillNewButton.Click();
            AddSkillField.SendKeys(Skill);
            this.dropDownSelector.getElementSelectedByValue(XpathConstants.SkillDropdown, "2");
            Global.GlobalDefinitions.driver.FindElement(By.XPath(XpathConstants.Addbutton)).Click();
        }
        public Boolean VerifySkill(string Skill)
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath(XpathConstants.SkillTableXPath), 10);
            int SkillFieldRecordCount = Global.GlobalDefinitions.driver.FindElements(By.XPath(XpathConstants.SkillTableXPath)).Count;
            bool recordFound = false;
            for (int i = 1; i <= SkillFieldRecordCount; i++)
            {
                var SkillText = Global.GlobalDefinitions.driver.FindElement(By.XPath(string.Format(XpathConstants.SkillUpdateFieldXPath, i))).Text;

                if (SkillText == Skill)
                {
                    recordFound = true;
                    break;
                }
            }
            return recordFound;
        }
        internal void EditSkill(string actualSkill, string newSkill)
        {
            ClickSkillTab.Click();
            int recordsCount = Global.GlobalDefinitions.driver.FindElements(By.XPath(XpathConstants.SkillTableXPath)).Count;
            for (int i = 1; i <= recordsCount; i++)
            {
                var skillName = Global.GlobalDefinitions.driver.FindElement(By.XPath(string.Format(XpathConstants.SkillUpdateFieldXPath, i))).Text;

                if (skillName == actualSkill)
                {
                    Global.GlobalDefinitions.driver.FindElement(By.XPath(string.Format(XpathConstants.skillEditButton, i))).Click();
                    IWebElement SkillEditField = Global.GlobalDefinitions.driver.FindElement(By.XPath(string.Format(XpathConstants.SkillUpdateField, actualSkill)));
                    SkillEditField.Clear();

                    SkillEditField.SendKeys(newSkill);
                    UpdateSkillButton.Click();

                    break;
                }


            }
        }//Delete functianlity
        internal void SkillDelete(string SkillToDelete)
        {
            Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            ClickSkillTab.Click();
            int SkillFieldRecordCount = Global.GlobalDefinitions.driver.FindElements(By.XPath(XpathConstants.SkillTableXPath)).Count;
            for (int i = 1; i <= SkillFieldRecordCount; i++)
            {
                var SkillFileText = Global.GlobalDefinitions.driver.FindElement(By.XPath(string.Format(XpathConstants.SkillUpdateFieldXPath, i))).Text;

                if (SkillFileText == SkillToDelete)
                {
                    IWebElement SkillDeleteButton = Global.GlobalDefinitions.driver.FindElement(By.XPath(string.Format(XpathConstants.DeleteSkillButton, i)));
                    SkillDeleteButton.Click();
                    break;
                }
            }
        }
    }
}
