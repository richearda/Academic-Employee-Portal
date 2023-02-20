using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class EvaluationCriteria
    {
        public int EvaluationCriteriaID { get; set; }
        public string EvaluationCriteriaDescription { get; set; }
        public bool? IsActive { get; set; }
        public virtual ICollection<EvaluationItem> EvaluationItems { get; set; }
    }
}
