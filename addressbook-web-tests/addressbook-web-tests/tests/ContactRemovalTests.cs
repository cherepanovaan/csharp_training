using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContacts = app.ContactHelper.GetContactList();

            if (! app.ContactHelper.IsContactOnPage())
            {
                ContactData contact = new ContactData("Test1", "Test1");
                app.ContactHelper.Create(contact);
            }
            app.ContactHelper.Remove(0);

            Assert.AreEqual(oldContacts.Count - 1, app.ContactHelper.GetContactCount());

            List<ContactData> newContacts = app.ContactHelper.GetContactList();

            ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
