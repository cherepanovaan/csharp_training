using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            if (! app.GroupHelper.IsGroupOnPage())
            {
                GroupData group = new GroupData("Test1");
                group.Header = "Test1";
                group.Footer = "Test1";

                app.GroupHelper.Create(group);
            }
            GroupData newData = new GroupData("TestModify");
            newData.Header = null;
            newData.Footer = null;

            app.GroupHelper.Modify(1, newData);
        }
    }
}
