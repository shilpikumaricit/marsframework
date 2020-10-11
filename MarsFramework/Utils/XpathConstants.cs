using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Utils
{
    class XpathConstants
    {
        // XPath constants for Language
        public static string AddNewLanguageButton = "(//div[@class='ui teal button '][contains(.,'Add New')])[1]";

        public static string AddLangaugeField = "//input[@placeholder='Add Language']";

        public static string LanguageTablePath = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody";

        public static string LanguageDropdownXPath = "//select[@class='ui dropdown']";

        public static string AddLanguageButton = "//input[@value='Add']";

        public static string EditLanguageButtonXPath = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[{0}]/tr/td[1]";

        public static string EditLanguageFieldXPath = "//input[contains(@value,'{0}')]";

        public static string EditButtonXPath = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[{0}]/tr/td[3]/span[1]/i";

        public static string LanguageFileTextXPath = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[{0}]/tr/td[1]";

        public static string DeleteLanguageButtonXPath = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[{0}]/tr/td[3]/span[2]/i";

        public static string UpdateLanguageXpath = "//input[contains(@value,'Update')]";
        //XpathConstants for skill functionality
        public static string SkillTab = "//a[contains(.,'Skills')]";
        public static string SkillAddNewButton = "//div[@class='ui teal button'][contains(.,'Add New')]";
        public static string AddSkillField = "//input[contains(@placeholder,'Add Skill')]";
        public static string SkillDropdown = "//select[@class='ui fluid dropdown']";
        public static string Addbutton = "//input[@value='Add']";
        public static string SkillTableXPath = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody";
        public static string skillEditButton = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[{0}]/tr/td[3]/span[1]/i";
        public static string SkillUpdateButton = "//input[@class='ui teal button']";

        // "//input[contains(@value,'Ruby1')]"
        public static string SkillUpdateField = "//input[contains(@value,'{0}')]";
        public static string DeleteSkillButton = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[{0}]/tr/td[3]/span[2]/i";
        public static string SkillUpdateFieldXPath = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[{0}]/tr/td[1]";

        // Education Start 
        public static string educationTabXPath = "//a[contains(@data-tab,'third')]";
        public static string educationAddNewXPath = "(//div[contains(.,'Add New')])[21]";
        public static string inputCollegeXPath = "//input[contains(@placeholder,'College/University Name')]";
        public static string inputDegreeXPath = "//input[contains(@placeholder,'Degree')]";
        public static string selectCountryXPath = "//select[contains(@name,'country')]";
        public static string selectTitleXPath = "//select[contains(@name,'title')]";
        public static string selectYearOfPassingXPath = "//select[contains(@name,'yearOfGraduation')]";
        public static string eductionTableXPath = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody";
        public static string certificateTableXPath = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody";
        public static string TableRowFieldValueXPath = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[{0}]/tr/td[2]";
        public static string certificateRowFieldValueXPath = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[{0}]/tr/td[1]";

        public static string EducationUpdateFieldXPath = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[{0}]/tr/td[2]";

        public static string EducationEditButton = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[{0}]/tr/td[6]/span[1]/i";

        public static string EducationUpdateField = "//input[contains(@value,'{0}')]";

        public static string EducationUpdateButton = "//input[contains(@value,'Update')]";
        internal static string DeleteEducationButton = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[{0}]/tr/td[6]/span[2]/i";
        // Education End
    }
}
