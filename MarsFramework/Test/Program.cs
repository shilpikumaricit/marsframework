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
            }

            [Test, Order(2)]
            public void EditSkill()
            {
                ManageListings manageListings = new ManageListings();
                manageListings.EditListing();
            }

            [Test, Order(3)]
            public void DeleteSkill()
            {
                ManageListings manageListings = new ManageListings();
                manageListings.DeleteListing();
            }
        }
    }
}