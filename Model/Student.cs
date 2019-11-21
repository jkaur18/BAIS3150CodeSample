using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jkaur18BAIS3150CodeSample.Model
{
    [System.Serializable]
    public class Student
    {
        [Required]
        [Key]
        public string Studentid { get; set; }

        [StringLength(25)]
        public string Firstname { get; set; }

        [StringLength(25)]
        public string Lastname { get; set; }

        [StringLength(50)]
        public string Email { get; set; }
        
        public string Programcode { get; set; }
    }
}
