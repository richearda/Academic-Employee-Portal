using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class PersonConfirmationQuestion
    {
        public int PersonConfirmationQuestionId { get; set; }
        public int? PersonId { get; set; }
        public int? ConfirmationQuestionId { get; set; }
        public bool? Response { get; set; }
        public string ResponseDetails { get; set; }
        public DateTime? DateFiled { get; set; }
        public string CaseStatus { get; set; }
        public bool? IsActive { get; set; }

        public virtual ConfirmationQuestion ConfirmationQuestion { get; set; }
        public virtual Person Person { get; set; }
    }
}
