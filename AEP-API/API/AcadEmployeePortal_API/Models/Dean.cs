using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class Dean
    {
        public int DeanID { get; set; }
        public int PersonID { get; set; }
        public Person Person { get; set; }
        public int CollegeID { get; set; }
        public College College { get; set; }
        public bool IsActive { get; set; }
    }
}
