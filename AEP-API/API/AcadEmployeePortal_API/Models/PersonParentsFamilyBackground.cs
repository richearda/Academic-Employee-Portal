using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class PersonParentsFamilyBackground
    {
        public int PersonParentsFamilyBackgroundId { get; set; }
        public int? PersonId { get; set; }
        public string FatherSurname { get; set; }
        public string FatherFirstName { get; set; }
        public string FatherMiddleName { get; set; }
        public string NameExtension { get; set; }
        public string MaidenName { get; set; }
        public string MotherSurname { get; set; }
        public string MotherFirstName { get; set; }
        public string MotherMiddleName { get; set; }
        public bool? IsActive { get; set; }

        public virtual Person Person { get; set; }
    }
}
