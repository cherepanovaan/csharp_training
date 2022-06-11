using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            List<ProjectData> oldProjects = ProjectData.GetAll();

            ProjectData project = new ProjectData(GenerateRandomString(10));
            app.ProjectHelper.CreateProject(project);

            List<ProjectData> newProjects = ProjectData.GetAll();
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);

            app.loginHelper.Logout();
        }

        [Test]
        public void AddNewProjectTest()
        {
            AccountData account = new AccountData("administrator", "root");

            ProjectData projectData = new ProjectData()
            {
                Name = GenerateRandomString(10)
            };

            List<ProjectData> oldProjects = app.API.GetProjectList(account);

            app.API.CreateNewProject(account, projectData);

            List<ProjectData> newProjects = app.API.GetProjectList(account);
            oldProjects.Add(projectData);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);

        }
    }
}
