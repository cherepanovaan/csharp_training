using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            if (GroupData.GetAll().Count == 0)
            {
                app.GroupHelper.Create(new GroupData(GenerateRandomString(30)));
            }

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            
            if (ContactData.GetAll().Except(oldList).ToList().Count == 0)
            {
                app.ContactHelper.Create(new ContactData(GenerateRandomString(30), GenerateRandomString(30)));
            }
            
            ContactData contact = ContactData.GetAll().Except(oldList).First();
            
            app.ContactHelper.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
