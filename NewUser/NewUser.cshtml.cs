using Lab1Final.Pages.DataClasses;
using Lab1Final.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Lab1Final.Pages
{
    public class NewUserModel : PageModel
    {
        [BindProperty]
        [Required]
        public Userss TempUser { get; set; }
       
        public void OnGet()
        {
          
        }

        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear();
            TempUser.firstName = "Populate Name";
            TempUser.lastName = "Populate Name";
            TempUser.email = "hello@gmail";
            TempUser.phoneNumber = "12345678";
            TempUser.role = "Admin";

            return Page();
        }

        public IActionResult OnPostClearHandler()
        {
            ModelState.Clear();
            TempUser.firstName = String.Empty;
            TempUser.lastName = String.Empty;
            TempUser.email = String.Empty;
            TempUser.phoneNumber = String.Empty;
            TempUser.role = String.Empty;

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
          
                return Page();
            }    
            
            DBClass.InsertSysUser(TempUser.firstName, TempUser.lastName, TempUser.email, TempUser.phoneNumber, TempUser.role);

            return RedirectToPage("../SysUser/SysUser");
        }
    }
}