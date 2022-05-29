﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_white
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void TestGroupRemoval()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData toBeRemoval = oldGroups[0];

            if (oldGroups.Count > 1)
            {
                app.Groups.Remove(toBeRemoval);

                Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupList().Count);

                List<GroupData> newGroups = app.Groups.GetGroupList();
                oldGroups.RemoveAt(0);

                Assert.AreEqual(oldGroups, newGroups);

            }
            else
            {
                app.Groups.RemoveTheOnlyGroup(toBeRemoval);
            }  
        }
    }
}
