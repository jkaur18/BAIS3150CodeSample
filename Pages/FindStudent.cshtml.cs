using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Jkaur18BAIS3150CodeSample.CustomExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jkaur18BAIS3150CodeSample.Pages
{
    public class FindStudentModel : PageModel
    {
        [TempData] public string Alert { get; set; }

        [BindProperty]
        [Required (ErrorMessage = "Student Id is required!" )]
        public string studentID { get; set; }

        [BindProperty]
        public Model.Student enrolledStudent { get; set; }

        [BindProperty]
        public bool foundStudent { get; set; }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Controller.BCS findstudent = new Controller.BCS();

                enrolledStudent = findstudent.FindStudent(studentID);

                foundStudent = enrolledStudent.Studentid != null ? true : false;
            }
            return Page();
        }            
    }
}