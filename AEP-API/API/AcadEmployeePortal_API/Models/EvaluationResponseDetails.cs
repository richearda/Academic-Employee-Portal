using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class EvaluationResponseDetails
    {
        public int EvaluationResponseDetailsId { get; set; }
        public int? EvaluationResponseId { get; set; }
        public int? EvaluationItemId { get; set; }
        public int? EvaluationRating { get; set; }

        public virtual EvaluationItem EvaluationItem { get; set; }
        public virtual EvaluationResponse EvaluationResponse { get; set; }
    }
}
