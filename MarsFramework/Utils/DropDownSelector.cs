using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MarsFramework.Utils
{
    class DropDownSelector
    {
        public SelectElement getElementSelectedByName(string Xpath, string name)
        {
            SelectElement selectElement = new SelectElement(Global.GlobalDefinitions.driver.FindElement(By.XPath(Xpath)));
            selectElement.SelectByText(name);
            return selectElement;
        }

        public SelectElement getElementSelectedByValue(string Xpath, string index)
        {
            var selectElement = new SelectElement(Global.GlobalDefinitions.driver.FindElement(By.XPath(Xpath)));
            selectElement.SelectByIndex(Int32.Parse(index));
            return selectElement;
        }
    }
}
