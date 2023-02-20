using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class Programs
    {
       [Key]
        public int ProgramID { get; set; }
        public string ProgramName { get; set; }
        public string ProgramCode { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
