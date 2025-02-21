using Lab1Final.Pages.DataClasses;
using Lab1Final.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;


namespace Lab1Final.Pages.SysUser
{
    public class SysUserModel : PageModel
    {
        public List<Userss> Users { get; set; }

        public SysUserModel()
        {
            Users = new List<Userss>();
        }

        public void OnGet()
        {
            DBClass.LabDBConnection.Close();
            SqlDataReader SysUserReader = DBClass.SysUserReader();
            while (SysUserReader.Read())
            {
                Users.Add(new Userss
                {
                    firstName = SysUserReader["firstName"].ToString(),
                    lastName = SysUserReader["lastName"].ToString(),
                    email = SysUserReader["email"].ToString(),
                    phoneNumber = SysUserReader["phoneNumber"].ToString(),
                    role = SysUserReader["role"].ToString()
                });
            }

            // Close the DB connection after use
            DBClass.LabDBConnection.Close();
        }
    }
}