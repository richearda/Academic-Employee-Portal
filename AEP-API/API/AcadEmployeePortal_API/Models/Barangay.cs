using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class Barangay
    {
        
        public int BarangayId { get; set; }
        public string BarangayName { get; set; }
        public bool? IsActive { get; set; }


       public virtual ICollection<Address> Addresses { get; set; }
        //Navigation Properties
       // public virtual ICollection<Person> PersonPermanentBarangayNavigations { get; set; }
        //public virtual ICollection<Person> PersonResidentialBarangayNavigations { get; set; }
    }
}
