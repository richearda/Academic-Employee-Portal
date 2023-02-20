using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.DTOs
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeNo { get; set; }
        public PersonDto Person { get; set; }
        public string EmployeeClassificationDescription { get; set; }
        public string ResolutionNo { get; set; }
        public string Designation { get; set; }
        public string DesignationStatus { get; set; }     
        public string Gsisidno { get; set; }
        public string Hdmfidno { get; set; }
        public string PhilHealthNo { get; set; }
        public string Sssidno { get; set; }
        public string Tinidno { get; set; }
    }
}
