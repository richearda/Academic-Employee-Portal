using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class LeaveApplication
    {
        public int LeaveApplicationId { get; set; }
        public DateTime? ApplicationDate { get; set; } //DateTime.Now.ToString("MM/dd/yyyy");
    public float NoOfDaysApplied { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsWithCommutation { get; set; }
        //Nav and FK Prop
        public int ApplicationStatusId { get; set; }
        public int LeaveTypeId { get; set; }
        public int EmployeeId { get; set; }
        public LeaveApplicationStatus ApplicationStatus { get; set; }
        public LeaveType LeaveType { get; set; }
        public Employee Employee { get; set; }


    }
}
