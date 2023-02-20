using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeNo { get; set; }
        public int? PersonId { get; set; }
        public int? EmployeeClassificationId { get; set; }
        public string ResolutionNo { get; set; }
        public string Designation { get; set; }
        public int? DesignationStatusId { get; set; }   
        public string Gsisidno { get; set; }
        public string Hdmfidno { get; set; }
        public string PhilHealthNo { get; set; }
        public string Sssidno { get; set; }
        public string Tinidno { get; set; }
        public bool? IsActive { get; set; }

        //Navigation Properties
        public virtual DesignationStatus DesignationStatus { get; set; }
        public virtual EmployeeClassification EmployeeClassification { get; set; }
       // public int EmployeeLeaveCreditsId { get; set; }
        
       // public EmployeeLeaveCredits EmployeeLeaveCredits { get; set; }
        public virtual Person Person { get; set; }
    }
}
