using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jkaur18BAIS3150CodeSample.Controller
{
    public class BCS
    {
        public Model.Student FindStudent(string StudentID)
        {
            Model.Student student;

            Model.Students studentmanager = new Model.Students();

            student = studentmanager.GetStudent(StudentID);

            return student;
        }
        public bool EnrollStudent(Model.Student acceptedStudent, string programCode)
        {
            bool confirmation;
            Model.Students studentmanager = new Model.Students();

            confirmation = studentmanager.AddStudent(acceptedStudent, programCode);

            return confirmation;
        }
        public bool ModifyStudent(Model.Student enrolledStudent)
        {
            bool confirmation;

            Model.Students studentmanager = new Model.Students();

            confirmation = studentmanager.UpdateStudent(enrolledStudent);

            return confirmation;
        }
        public bool RemoveStudent(string StudentID)
        {
            bool confirmation;

            Model.Students studentmanager = new Model.Students();

            confirmation = studentmanager.DeleteStudent(StudentID);

            return confirmation;
        }
        public Model.Program FindProgram(string programCode)
        {
            Model.Program program;

            Model.Programs ProgramManager = new Model.Programs();

            program = ProgramManager.GetProgram(programCode);

            return program;
        }
        public bool CreateProgram(string programCode, string Description)
        {
            bool confirmation;

            Model.Programs ProgramManager = new Model.Programs();

            confirmation = ProgramManager.AddProgram(programCode, Description);

            return confirmation;
        }

    }
}
