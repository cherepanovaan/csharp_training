using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();

            if (! app.GroupHelper.IsGroupOnPage())
            {
                GroupData group = new GroupData("Test1ForDelete");
                group.Header = "Test1ForDelete";
                group.Footer = "Test1ForDelete";

                app.GroupHelper.Create(group);
            }
            app.GroupHelper.Remove(0);

            List<GroupData> newGroups = app.GroupHelper.GetGroupList();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
