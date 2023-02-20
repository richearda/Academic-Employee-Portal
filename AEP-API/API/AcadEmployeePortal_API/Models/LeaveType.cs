using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class LeaveType
    {
        public int LeaveTypeId { get; set; }
        public string LeaveTypeName { get; set; }
        public string LeaveTypeDescription { get; set; }
    }
}
