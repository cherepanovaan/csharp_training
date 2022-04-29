using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            if (! app.ContactHelper.IsContactOnPage())
            {
                ContactData contact = new ContactData("Test1", "Test1");

                app.ContactHelper.Create(contact);
            }
            ContactData newContact = new ContactData("Test Modify", "Test last Modify");

            app.ContactHelper.Modify(1, newContact);
        }
    }
}
