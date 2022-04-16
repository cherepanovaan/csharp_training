using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            navigationHelper.GoToHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            contactHelper.AddNewContactPage();
            ContactData contact = new ContactData("Test name", "Test last name");
            contactHelper.FillContactForm(contact);
            contactHelper.SubmitCreation();
            loginHelper.Logout();
        }
    }
}
