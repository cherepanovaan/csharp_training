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
        public void GroupRemovalTest()
        {
            if (! app.ContactHelper.IsContactOnPage())
            {
                ContactData contact = new ContactData("Test1", "Test1");
                app.ContactHelper.Create(contact);
            }
            app.ContactHelper.Remove(1);
        }
    }
}
