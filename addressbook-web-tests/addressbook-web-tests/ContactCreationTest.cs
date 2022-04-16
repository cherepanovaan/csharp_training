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
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            AddNewContactPage();
            ContactData contact = new ContactData("Test name", "Test last name");
            FillContactForm(contact);
            SubmitCreation();
            GoToHomePage();
            Logout();
        }
    }
}
