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
    public class FindProgramModel : PageModel
    {
        [TempData] public string Alert { get; set; }

        [BindProperty]
        [Required (ErrorMessage = "Program code is required!")]
        public string programCode { get; set; }

        public bool foundProgram { get; set; }

        public bool studentList { get; set; }

        public Model.Program activeProgram { get; set; }

        public ActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                Controller.BCS RequestDirector = new Controller.BCS();

                activeProgram = RequestDirector.FindProgram(programCode);
            }
            return Page();
        }
    }
}