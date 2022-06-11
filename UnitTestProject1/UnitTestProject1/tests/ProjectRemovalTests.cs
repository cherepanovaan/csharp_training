using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
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
    }
}
