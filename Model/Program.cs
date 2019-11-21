using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jkaur18BAIS3150CodeSample.Model
{
    public class Program
    {
        public Program(string programCode)
        {
            Students student = new Students();
            EnrolledStudents = student.GetStudents(programCode);
        }
        [Key]
        [StringLength(10)]
        public string programCode { get; set; }
        [StringLength(60)]
        public string Description { get; set; }
        public List<Student> EnrolledStudents { get; }
    }
}
