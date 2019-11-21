using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jkaur18BAIS3150CodeSample.Pages
{
    public class EnrollStudentModel : PageModel
    {
        [BindProperty]
        [Required (ErrorMessage ="Student Id is required!")]
        public string studentID { get; set; }

        [BindProperty]
        [Required (ErrorMessage = "First Name is required!")]
        public string firstName { get; set; }

        [BindProperty]
        [Required (ErrorMessage = "Last Name is required!")]
        public string lastName { get; set; }

        [BindProperty]
        [Required (ErrorMessage = "Email is required!")]
        [RegularExpression(@"^[^@]+@[^\.]+\..+$", ErrorMessage = "Enter a Valid Email Address")]
        public string eMail { get; set; }

        [BindProperty]
        [Required (ErrorMessage = "Program Code is required!")]
        public string programCode { get; set; }

        [BindProperty]        
        public bool studentAdded { get; set; }

        [BindProperty]
        public Model.Student enrolledStudent { get; set; }

        [TempData] public string Alert { get; set; }
       
        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                enrolledStudent.Studentid = studentID;
                enrolledStudent.Firstname = firstName;
                enrolledStudent.Lastname = lastName;
                enrolledStudent.Email = eMail;

                Controller.BCS RequestDirector = new Controller.BCS();

                studentAdded = RequestDirector.EnrollStudent(enrolledStudent, programCode);

                if(studentAdded)
                {
                    Alert = $"Student Created Successfully";

                    return RedirectToPage("FindStudent");
                }
            }
            return Page();
        }
    }
}