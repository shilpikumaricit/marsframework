using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;

namespace MarsFramework.Test
{
    [TestFixture]
    [Category("Sprint2")]
    class AdvanceTasks : Global.Base
    {
        ExtentTest test;

        

        //

        [Test, Order(1)]
        public void AddLanguage()
        {

            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            test = extent.CreateTest("Add Language Skill");
            test.Log(Status.Info, "Starting the Add Language Test");
            LanguagePage AddLanguage = new LanguagePage();
            AddLanguage.Addlanguage(GlobalDefinitions.ExcelLib.ReadData(2, "Language"), GlobalDefinitions.ExcelLib.ReadData(2, "Level"));
            bool actual = AddLanguage.VerifyLanguage(GlobalDefinitions.ExcelLib.ReadData(2, "Language"));
            if (actual)
            {
                test.Log(Status.Pass, "Add Language Successfull");
                Assert.IsTrue(actual);
            }
            else
            {
                test.Log(Status.Fail, "Add Language Failed");
                Assert.IsTrue(actual);
            }
        }

        //Add Education
        [Test, Order(2)]
        public void AddEducation()
        {

            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            test = extent.CreateTest("Add Education to Profile");
            test.Log(Status.Info, "Starting the Add Education to profile Test");
            EducationPage education = new EducationPage();
            education.AddEduction(GlobalDefinitions.ExcelLib.ReadData(2, "University"), 
                GlobalDefinitions.ExcelLib.ReadData(2, "Country"),
                GlobalDefinitions.ExcelLib.ReadData(2, "Title"),
                GlobalDefinitions.ExcelLib.ReadData(2, "Degree"),
                GlobalDefinitions.ExcelLib.ReadData(2, "Year Of Graduation"));

            bool actual = education.VerifyDegree(GlobalDefinitions.ExcelLib.ReadData(2, "University"),
                GlobalDefinitions.ExcelLib.ReadData(2, "Country"),
                GlobalDefinitions.ExcelLib.ReadData(2, "Title"),
                GlobalDefinitions.ExcelLib.ReadData(2, "Degree"),
                GlobalDefinitions.ExcelLib.ReadData(2, "Year Of Graduation"));
            if (actual)
            {
                test.Log(Status.Pass, "Add Education Successfull");
                Assert.IsTrue(actual);
            }
            else
            {
                test.Log(Status.Fail, "Add Education Failed");
                Assert.IsTrue(actual);
            }
        }

        // Add Skill
        [Test, Order(3)]
        public void AddSkill()
        {

            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            test = extent.CreateTest("Add Skill to Profile");
            test.Log(Status.Info, "Starting the Add Skill to profile Test");
            SkillPage skillPage = new SkillPage();
            skillPage.AddSkill(
                GlobalDefinitions.ExcelLib.ReadData(2, "Skill"),
                GlobalDefinitions.ExcelLib.ReadData(2, "Skill Level"));

            bool actual = skillPage.VerifySkill(
                GlobalDefinitions.ExcelLib.ReadData(2, "Skill"));
            if (actual)
            {
                test.Log(Status.Pass, "Add Skill Successfull");
                Assert.IsTrue(actual);
            }
            else
            {
                test.Log(Status.Fail, "Add Skill Failed");
                Assert.IsTrue(actual);
            }
        }

        // Add Certificate
        [Test, Order(3)]
        public void AddCertificate()
        {

            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            test = extent.CreateTest("Add Certificate to Profile");
            test.Log(Status.Info, "Starting the Add Certificate to profile Test");
            CertificationPage certificationPage = new CertificationPage();
            certificationPage.AddCertificate(
                GlobalDefinitions.ExcelLib.ReadData(2, "Certificate"),
                GlobalDefinitions.ExcelLib.ReadData(2, "CertifiedFrom"));

            bool actual = certificationPage.VerifyCertificationPage(
                GlobalDefinitions.ExcelLib.ReadData(2, "Certificate"));
            if (actual)
            {
                test.Log(Status.Pass, "Add Certificate Successfull");
                Assert.IsTrue(actual);
            }
            else
            {
                test.Log(Status.Fail, "Add Certificate Failed");
                Assert.IsTrue(actual);
            }
        }

        [Test, Order(5)]
        public void EditAvailability()
        {
            test = extent.CreateTest("Add Share Skill");
            test.Log(Status.Info, "Starting the Add Skill Test");
            AddLanguage ProfilePage = new AddLanguage();
            ProfilePage.EditAvailability();
            bool actual = manageListing.Verify();
            if (actual)
            {
                test.Log(Status.Pass, "Add Skill Successfull");
                Assert.IsTrue(actual);
            }
            else
            {
                test.Log(Status.Fail, "Add Skill Failed");
                Assert.IsTrue(actual);
            }
        }

    }
}
