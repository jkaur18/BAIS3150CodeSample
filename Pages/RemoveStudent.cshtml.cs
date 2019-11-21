using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jkaur18BAIS3150CodeSample.Pages
{
    public class RemoveStudentModel : PageModel
    {        
        [TempData] public string Alert { get; set; }

        [BindProperty]
        public Model.Student EnrolledStudent { get; set; }

        [BindProperty]
        public bool Confirmation { get; set; }

        Controller.BCS RequestDirector = new Controller.BCS();

        public void OnGet()
        {
            string id = Request.Query["id"];

            EnrolledStudent = RequestDirector.FindStudent(id);
        }

        public ActionResult OnPost()
        {
            string id = Request.Query["id"];

            Confirmation = RequestDirector.RemoveStudent(id);

            if (Confirmation)
            {
                Alert = $"Student deleted successfully!";

                return RedirectToPage("FindStudent");
            }

            return Page();
        }
    }
}