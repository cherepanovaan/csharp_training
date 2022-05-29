using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemovingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovingContactFromGroup()
        {
            if (GroupData.GetAll().Count == 0)
            {
                app.GroupHelper.Create(new GroupData(GenerateRandomString(30)));
            }

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();

            if (oldList.Count == 0)
            {
                List<ContactData> contacts = ContactData.GetAll();

                if (contacts.Count == 0)
                {
                    app.ContactHelper.Create(new ContactData(GenerateRandomString(30), GenerateRandomString(30)));
                }
                
                ContactData contact = ContactData.GetAll().First();
                app.ContactHelper.AddContactToGroup(contact, group);
                oldList = group.GetContacts();
            }

            app.ContactHelper.RemoveContactFromGroup(oldList[0], group);

            List<ContactData> newList = group.GetContacts();
            oldList.RemoveAt(0);

            Assert.AreEqual(oldList, newList);
        }

    }
}
