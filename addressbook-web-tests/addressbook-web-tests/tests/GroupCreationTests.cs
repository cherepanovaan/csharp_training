using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("Test2Name");
            group.Header = "Test2Header";
            group.Footer = "Test2Footer";

            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();

            app.GroupHelper.Create(group);

            List<GroupData> newGroups = app.GroupHelper.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);  
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();

            app.GroupHelper.Create(group);

            List<GroupData> newGroups = app.GroupHelper.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();

            app.GroupHelper.Create(group);

            List<GroupData> newGroups = app.GroupHelper.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
    }
}

