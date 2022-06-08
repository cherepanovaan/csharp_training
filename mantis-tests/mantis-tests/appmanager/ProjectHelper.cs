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

        public void RemoveProject(ProjectData project)
        {
            manager.Menu.GoToControlMenu();

            GoToControlProject();
            SelectProject(project.Id);
            Remove();
            Remove();
        }

        public void SelectProject(string index)
        {
            driver.FindElement(By.XPath("//a[@href='manage_proj_edit_page.php?project_id="+ index +"']")).Click();
        }

        public void Remove()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }

        public void GoToControlProject()
        {
            driver.FindElement(By.XPath("//a[@href='" + hrefBase + "/manage_proj_page.php']")).Click();
        }

        public void GoToAddNewProject()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        public void FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.Name("name")).SendKeys(project.Name);
        }

        public void SubmitCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
        }
    }
}
