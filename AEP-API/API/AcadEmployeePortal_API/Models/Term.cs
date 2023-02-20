using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class Term
    {

        public int TermId { get; set; }
        public string TermName { get; set; }
        public string TermCode { get; set; }
        public bool? IsCurrent { get; set; }
        public bool? IsActive { get; set; }

        //public virtual ICollection<Curriculum> Curricula { get; set; }
        //public virtual ICollection<EvaluationResponse> EvaluationResponses { get; set; }
        //public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
