using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager) { }

        public void CreateProject(ProjectData project)
        {
            manager.Menu.GoToControlMenu();

            GoToControlProject();
            GoToAddNewProject();
            FillProjectForm(project);
            SubmitCreation();
        }

        private void GoToControlProject()
        {
            driver.FindElement(By.XPath("//a[@href='/mantisbt-2.25.4/manage_proj_page.php']")).Click();
        }

        private void GoToAddNewProject()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        private void FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.Name("name")).SendKeys(project.Name);
        }

        private void SubmitCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
        }
    }
}
