using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class Major
    {
        public int MajorID { get; set; }
        public string MajorName { get; set; }
        public string MajorCode { get; set; }
        public bool IsActive { get; set; }
    }
}
