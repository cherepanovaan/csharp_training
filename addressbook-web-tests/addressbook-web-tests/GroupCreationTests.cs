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
            navigationHelper.GoToHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            navigationHelper.GoToGroupsPage();
            groupHelper.InitNewGroupCreation();
            GroupData group = new GroupData("Test2Name");
            group.Header = "Test2Header";
            group.Footer = "Test2Footer";
            groupHelper.FillGroupForm(group);
            groupHelper.SubmitCreation();
            groupHelper.ReturnToGroupPage();
            loginHelper.Logout();
        }
    }
}

