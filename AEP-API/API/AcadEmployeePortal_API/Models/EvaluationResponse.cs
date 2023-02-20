using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class EvaluationResponse
    {

        public int EvaluationResponseId { get; set; }
        public int? EvaluatedByPersonId { get; set; }
        public int? EvaluationForPersonId { get; set; }
        public int? TermId { get; set; }
        public int? SemesterId { get; set; }
        public DateTime EvaluationDate { get; set; }

        public virtual Person EvaluatedByPerson { get; set; }
        public virtual Person EvaluationForPerson { get; set; }
        public virtual Semester Semester { get; set; }
        public virtual Term Term { get; set; }
        public virtual ICollection<EvaluationResponseDetails> EvaluationResponseDetails { get; set; }
    }
}
