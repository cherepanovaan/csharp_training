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
            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();
            GroupData oldData = oldGroups[0];

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

            app.GroupHelper.Modify(0, newData);

            Assert.AreEqual(oldGroups.Count, app.GroupHelper.GetGroupCount());

            List<GroupData> newGroups = app.GroupHelper.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
