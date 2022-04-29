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
            List<ContactData> oldContacts = app.ContactHelper.GetContactList();

            if (! app.ContactHelper.IsContactOnPage())
            {
                ContactData contact = new ContactData("Test1", "Test1");

                app.ContactHelper.Create(contact);
            }
            ContactData newContact = new ContactData("TestModify", "TestlastModify");

            app.ContactHelper.Modify(0, newContact);

            List<ContactData> newContacts = app.ContactHelper.GetContactList();
            oldContacts[1].FirstName = newContact.FirstName;
            oldContacts[1].LastName = newContact.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
