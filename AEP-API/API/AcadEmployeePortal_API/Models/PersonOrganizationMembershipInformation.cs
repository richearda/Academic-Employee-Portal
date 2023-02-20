using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class PersonOrganizationMembershipInformation
    {
        public int PersonOrganizationMembershipInformationId { get; set; }
        public int? PersonId { get; set; }
        public string MembershipDetails { get; set; }
        public bool? IsActive { get; set; }

        public virtual Person Person { get; set; }
    }
}
