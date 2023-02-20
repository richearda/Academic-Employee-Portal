using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class PersonOathDeclaration
    {
        public int PersonOathDeclarationId { get; set; }
        public int? PersonId { get; set; }
        public string Photo { get; set; }
        public string RightThumbmark { get; set; }
        public int? GovernmentIssuedIdentificationId { get; set; }
        public string Idno { get; set; }
        public DateTime? IssuanceDate { get; set; }
        public string IssuancePlace { get; set; }
        public string Signature { get; set; }
        public DateTime? DateAccomplished { get; set; }
        public DateTime? DateSworn { get; set; }
        public string AdministeringOathPerson { get; set; }
        public bool? IsActive { get; set; }

        public virtual GovernmentIssuedIdentification GovernmentIssuedIdentification { get; set; }
        public virtual Person Person { get; set; }
    }
}
