using Lab1Final.Pages.DataClasses;
using Lab1Final.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab1Final.Pages.Projects
{
    public class ManageProjectsModel : PageModel
    {
        public List<Project> Projectss { get; set; }

        public ManageProjectsModel()
        {
            Projectss = new List<Project>();
        }

        public void OnGet()
        {
            SqlDataReader ProjectsReader = DBClass.ProjectsReader();
            while (ProjectsReader.Read())
            {
                Projectss.Add(new Project
                {
                    projectName = ProjectsReader["ProjectName"].ToString(),
                    projectDueDate = ProjectsReader["ProjectDueDate"].ToString(),
                });
            }

            // Close the DB connection after use
            DBClass.LabDBConnection.Close();
        }
    }
}
