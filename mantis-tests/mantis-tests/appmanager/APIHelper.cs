using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public void CreateNewProject(AccountData account, ProjectData projectData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData project = new Mantis.ProjectData();
            project.name = projectData.Name;
            client.mc_project_add(account.Name, account.Password, project);
        }

        public List<ProjectData> GetProjectList(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible(account.Name, account.Password);
            List<ProjectData> allProjects = new List<ProjectData>();
            
            foreach (Mantis.ProjectData project in projects)
            {
                ProjectData pr = new ProjectData();
                pr.Id = project.id;
                pr.Name = project.name;
                allProjects.Add(pr);
            }
            return allProjects;
        }

        public void DeleteProject(AccountData account, ProjectData projectRemoved)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient(); 
            client.mc_project_delete(account.Name, account.Password, projectRemoved.Id);
        }
    }
}
