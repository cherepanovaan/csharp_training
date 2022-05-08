using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.ContactHelper.GetContactInfoFromTable(2);
            ContactData fromForm = app.ContactHelper.GetContactInfoFromEditForm(2);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void TestContactDetails()
        {
            string fromDetails = app.ContactHelper.GetContactInfoFromDetails(2);
            ContactData fromForm = app.ContactHelper.GetContactInfoFromEditForm(2);

            Assert.AreEqual(fromDetails, fromForm.AllInfo);
        }
    }
}
