using System;
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

            [Test, Order(1)]
            public void AddSkill()
            {
                ShareSkill shareSkill = new ShareSkill();
                shareSkill.EnterShareSkill();
                bool actual = manageListing.Verify();
                if (actual)
                {
                    Assert.IsTrue(actual);
                }
                else
                {
                    throw new Exception("Add to Share Skill Failed");
                }
            }

            [Test, Order(2)]
            public void EditSkill()
            {
                manageListing.EditListing();
                bool actual = manageListing.Verify();
                if (actual)
                {
                    Assert.IsTrue(actual);
                }
                else
                {
                    throw new Exception("Edit to Manage Listing Failed");
                }
            }

            [Test, Order(3)]
            public void DeleteSkill()
            {
                manageListing.DeleteListing();
                bool actual = manageListing.Verify();
                if (!actual)
                {
                    Assert.IsFalse(actual);
                }
                else
                {
                    throw new Exception("Delete to Manage Listing Failed");
                }
            }
        }
    }
}