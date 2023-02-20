using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class EmployeeLeaveCredits
    {
        [Key]
        public int EmployeeLeaveCreditsId { get; set; }
        public DateTime Date { get; set; }
        public float EarnedLeaveCredits { get; set; }
        public float UsedLeaveCredits { get; set; }
        public float UnusedLeaveCredits { get; set; }
        public float TotalCredits { get; set; }
        //Nav Prop
        //[ForeignKey("EmployeeId")]
        //public int EmployeeId { get; set; }        
        //public ICollection<Employee> Employee { get; set; }
    }
}
