using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jkaur18BAIS3150CodeSample.Pages
{
    public class ModifyStudentModel : PageModel
    {
        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
        public string LastName { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public Model.Student EnrolledStudent { get; set; }

       
        [TempData] public string Alert { get; set; }


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
            EnrolledStudent.Studentid = id;
            EnrolledStudent.Firstname = FirstName;
            EnrolledStudent.Lastname = LastName;
            EnrolledStudent.Email = Email;

            Confirmation = RequestDirector.ModifyStudent(EnrolledStudent);

            if (Confirmation)
            {
                Alert = $"Student Updated successfully!";

                return RedirectToPage("FindStudent");
            }

            return Page();
        }
    }
}