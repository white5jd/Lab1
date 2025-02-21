using Lab1Final.Pages.DataClasses;
using Lab1Final.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Lab1Final.Pages.ManageGrants
{
    public class ManageGrantsModel : PageModel
    {

        [BindProperty]
        [Required]
        public Grant TempGrant { get; set; }


        public void OnGet()
        {

        }
        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear();
            TempGrant.grantName = "Populate Grant Name";
            TempGrant.submissionDate = "Populated Submission Date";
            TempGrant.awardDate = "Populate Award Date";
            TempGrant.awardAmount = 5000;
            TempGrant.grantStatus = "Status";
            TempGrant.grantCategory = "Category";
       

            return Page();
        }
        public IActionResult OnPostClearHandler()
        {
            ModelState.Clear();
            TempGrant.grantName = string.Empty;
            TempGrant.submissionDate = string.Empty;
            TempGrant.awardDate = string.Empty;
            TempGrant.awardAmount = 0;
            TempGrant.grantStatus = string.Empty;
            TempGrant.grantCategory = string.Empty;
     

            return Page();
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {

                return Page();
            }

            DBClass.InsertGrantTable(TempGrant.grantName, TempGrant.submissionDate, TempGrant.awardDate, TempGrant.awardAmount, TempGrant.grantStatus, TempGrant.grantCategory);

            return RedirectToPage("Grants");
        }
    }
}
