using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class GovernmentIssuedIdentification
    {
        public int GovernmentIssuedIdentificationId { get; set; }
        public string IssuedIdentificationType { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<PersonOathDeclaration> PersonOathDeclarations { get; set; }
    }
}
