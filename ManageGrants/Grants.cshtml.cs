using Lab1Final.Pages.DataClasses;
using Lab1Final.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab1Final.Pages.Grants
{
    public class ManageGrantsModel : PageModel
    {
        public List<Grant> Grantss { get; set; }

        public ManageGrantsModel()
        {
            Grantss = new List<Grant>();
        }

        public void OnGet()
        {
            DBClass.LabDBConnection.Close();
            SqlDataReader GrantsReader = DBClass.GrantsReader();
            while (GrantsReader.Read())
            {
                Grantss.Add(new Grant
                {
                    grantName = GrantsReader["grantName"].ToString(),
                    submissionDate = GrantsReader["SubmissionDate"].ToString(),
                    awardDate = GrantsReader["awardDate"].ToString(),
                    awardAmount = GrantsReader["awardAmount"] != DBNull.Value
                    ? Convert.ToDecimal(GrantsReader["awardAmount"])  // Now assigning a decimal value, not a string
        : 0m,
                    grantStatus = GrantsReader["grantStatus"].ToString(),
                    grantCategory = GrantsReader["grantCategory"].ToString(),
                });
            }

            // Close the DB connection after use
            DBClass.LabDBConnection.Close();
        }
    }
}