using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class CivilStatus
    {

        public int CivilStatusId { get; set; }
        public string CivilStatusType { get; set; }
        public string CivilStatusCode { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Person> People { get; set; }


    }
}
