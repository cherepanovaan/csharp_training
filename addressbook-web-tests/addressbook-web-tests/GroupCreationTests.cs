using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitNewGroupCreation();
            GroupData group = new GroupData("Test2Name");
            group.Header = "Test2Header";
            group.Footer = "Test2Footer";
            FillGroupForm(group);
            SubmitCreation();
            ReturnToGroupPage();
            Logout();
        }
    }
}

