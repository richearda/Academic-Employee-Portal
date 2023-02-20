using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePortal.Models
{
    public class User
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        //public bool IsDean()
        //{
        //    if (Role == "Dean")
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
                    
        //}
    }
}
