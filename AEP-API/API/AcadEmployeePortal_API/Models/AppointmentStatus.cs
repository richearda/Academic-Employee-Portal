using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class AppointmentStatus
    {
        public int AppointmentStatusId { get; set; }
        public string AppointmentStatusDescription { get; set; }
        public string IsActive { get; set; }

       
    }
}
