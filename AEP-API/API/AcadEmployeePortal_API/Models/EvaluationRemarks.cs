using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class EvaluationRemarks
    {
        [Key]
        public int EvaluationItemRemarksId { get; set; }
        public string EvaluationItemRemarksDescription { get; set; }
        public string EvaluationItemRemarksCode { get; set; }
        public int? EvaluationItemRemarksWeight { get; set; }
        public bool? IsActive { get; set; }
    }
}
