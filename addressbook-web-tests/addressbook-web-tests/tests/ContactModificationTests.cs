using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldData = oldContacts[1];

            if (! app.ContactHelper.IsContactOnPage())
            {
                ContactData contact = new ContactData("Test1", "Test1");

                app.ContactHelper.Create(contact);
            }
            ContactData newContact = new ContactData("TestModify", "TestlastModify");

            app.ContactHelper.Modify(oldData, newContact);

            Assert.AreEqual(oldContacts.Count, app.ContactHelper.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
            oldData.FirstName = newContact.FirstName;
            oldData.LastName = newContact.LastName;
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
