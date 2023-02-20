using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class LeaveApplicationStatus
    {
        [Key]
        public int ApplicationStatusId { get; set; }
        public bool IsApproved { get; set; }
        public float TotalDaysApproved { get; set; }
        public string Description { get; set; }
    }
}
