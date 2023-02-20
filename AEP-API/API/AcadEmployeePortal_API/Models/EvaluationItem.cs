using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class EvaluationItem
    {
        public int EvaluationItemId { get; set; }
        public int? EvaluationPart { get; set; }
        public int? EvaluationCriteriaId { get; set; }
        public int? EvaluationItemNo { get; set; }
        public string EvaluationItemDetails { get; set; }
        public bool? IsActive { get; set; }

        public virtual EvaluationRemarks EvaluationRemarks { get; set; }
        public virtual EvaluationCriteria EvaluationCriteria { get; set; }
        public virtual ICollection<EvaluationResponseDetails> EvaluationResponseDetails { get; set; }
    }
}
