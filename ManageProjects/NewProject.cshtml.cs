using System.ComponentModel.DataAnnotations;
using Lab1Final.Pages.DataClasses;
using Lab1Final.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab1Final.Pages.ManageProjects
{
    public class NewProjectModel : PageModel
    {

        [BindProperty]
        [Required]
        public Project TempProject { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear();
            TempProject.projectName = "Populate Name";
            TempProject.projectDueDate = "Populate Date";

            return Page();
        }
        public IActionResult OnPostClearHandler()
        {
            ModelState.Clear();
            TempProject.projectName = string.Empty;
            TempProject.projectDueDate = string.Empty;

            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            DBClass.InsertProject(TempProject.projectName, TempProject.projectDueDate);
            return RedirectToPage("Projects");
        }

    }
}
