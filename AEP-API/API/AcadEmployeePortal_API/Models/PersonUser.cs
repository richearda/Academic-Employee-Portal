using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class PersonUser
    {
        public int PersonUserId { get; set; }
        public int? PersonId { get; set; }
        public int? UserId { get; set; }

        public virtual Person Person { get; set; }
        public virtual User User { get; set; }
    }
}
