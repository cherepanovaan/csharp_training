using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : TestBase
    {
        [Test]
        public void ProjectRemovalTest()
        {
            List<ProjectData> oldProjects = ProjectData.GetAll();

            if (oldProjects.Count == 0)
            {
                ProjectData project = new ProjectData(GenerateRandomString(10));
                app.ProjectHelper.CreateProject(project);
                oldProjects = ProjectData.GetAll();
            }
            ProjectData projectRemoved = oldProjects[0];

            app.ProjectHelper.RemoveProject(projectRemoved);

            List<ProjectData> newProjects = ProjectData.GetAll();
            oldProjects.RemoveAt(0);

            Assert.AreEqual(oldProjects, newProjects);

            foreach (ProjectData project in newProjects)
            {
                Assert.AreNotEqual(project.Id, projectRemoved.Id);
            }

            app.loginHelper.Logout();
        }

        [Test]
        public void DeleteProjectTest()
        {
            AccountData account = new AccountData("administrator", "root");

            List<ProjectData> oldProjects = app.API.GetProjectList(account);

            if (oldProjects.Count == 0)
            {
                ProjectData project = new ProjectData(GenerateRandomString(10));
                app.API.CreateNewProject(account, project);
                oldProjects = app.API.GetProjectList(account);
            }
            ProjectData projectRemoved = oldProjects[0];

            app.API.DeleteProject(account, projectRemoved);

            List<ProjectData> newProjects = app.API.GetProjectList(account);
            oldProjects.RemoveAt(0);

            Assert.AreEqual(oldProjects, newProjects);

            foreach (ProjectData project in newProjects)
            {
                Assert.AreNotEqual(project.Id, projectRemoved.Id);
            }
        }
    }
}
