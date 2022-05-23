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
            GroupData group = GroupData.GetAll()[1];
            List<ContactData> oldList = group.GetContacts();

            app.ContactHelper.RemoveContactFromGroup(oldList[0], group);

            List<ContactData> newList = group.GetContacts();
            oldList.RemoveAt(0);

            Assert.AreEqual(oldList, newList);
        }

    }
}
