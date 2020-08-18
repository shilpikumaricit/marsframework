using System;
using AventStack.ExtentReports;
using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {
            ExtentTest test;

            [Test, Order(1)]
            public void AddSkill()
            {
                test = extent.CreateTest("Add Share Skill");
                test.Log(Status.Info, "Starting the Add Skill Test");
                ShareSkill shareSkill = new ShareSkill();
                shareSkill.EnterShareSkill();
                bool actual = manageListing.Verify();
                if (actual)
                {
                    test.Log(Status.Pass, "Add Skill Successfull");
                    Assert.IsTrue(actual);
                }
                else
                {
                    test.Log(Status.Fail, "Add Skill Failed");
                    throw new Exception("Add to Share Skill Failed");
                }
                //extent.Flush();
            }

            [Test, Order(2)]
            public void EditSkill()
            {
                test = extent.CreateTest("Edit Managing Listing Skill");
                test.Log(Status.Info, "Starting the Edit Skill Test");
                manageListing.EditListing();
                bool actual = manageListing.Verify();
                if (actual)
                {
                    test.Log(Status.Pass, "Edit manage listing Skill Successfull");
                    Assert.IsTrue(actual);
                }
                else
                {
                    test.Log(Status.Fail, "Edit manage listing Skill Failed");
                    throw new Exception("Edit to Manage Listing Failed");
                }
            }

            [Test, Order(3)]
            public void DeleteSkill()
            {
                test = extent.CreateTest("Delete Managing Listing");
                test.Log(Status.Info, "Starting the Delete Skill Test");
                manageListing.DeleteListing();
                bool actual = manageListing.Verify();
                if (!actual)
                {
                    test.Log(Status.Pass, "Delete manage listing Skill Successfull");
                    Assert.IsFalse(actual);
                }
                else
                {
                    test.Log(Status.Fail, "Delete manage listing Skill Failed");
//                    throw new Exception("Delete to Manage Listing Failed");
                }
            }
        }
    }
}