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
            ContactData oldData = oldContacts[0];

            if (! app.ContactHelper.IsContactOnPage())
            {
                ContactData contact = new ContactData("Test1", "Test1");

                app.ContactHelper.Create(contact);
            }
            ContactData newContact = new ContactData("TestModify", "TestlastModify");

            app.ContactHelper.Modify(0, newContact);

            Assert.AreEqual(oldContacts.Count, app.ContactHelper.GetContactCount());

            List<ContactData> newContacts = app.ContactHelper.GetContactList();
            oldContacts[0].FirstName = newContact.FirstName;
            oldContacts[0].LastName = newContact.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newContact.FirstName, contact.FirstName);
                    Assert.AreEqual(newContact.LastName, contact.LastName);
                }
            }
        }
    }
}
