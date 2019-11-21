using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jkaur18BAIS3150CodeSample.Pages
{
    public class CreateProgramModel : PageModel
    {
        [TempData] public string Alert { get; set; }
        
        [BindProperty]
        [Required (ErrorMessage ="Program Code is required!")]
        public string programCode { get; set; }
        [BindProperty]
        [Required (ErrorMessage = "Program Description is required!")]
        public string description { get; set; }
        public bool programAdded { get; set; }
        public void OnGet()
        {

        }
        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Controller.BCS RequestDirector = new Controller.BCS();

                programAdded = RequestDirector.CreateProgram(programCode, description);

                if(programAdded)
                {
                    Alert = $"Program created successfully";

                    return RedirectToPage("FindProgram");
                }
            }

            return Page();
        }
    }
}