using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class ConfirmationQuestion
    {
        public int ConfirmationQuestionId { get; set; }
        public int? ParentQuestionId { get; set; }
        public int? QuestionNo { get; set; }
        public string QuestionDetails { get; set; }
        public bool? IsActive { get; set; }

        public virtual ConfirmationQuestion ParentQuestion { get; set; }
        public virtual ICollection<ConfirmationQuestion> InverseParentQuestion { get; set; }
        public virtual ICollection<PersonConfirmationQuestion> PersonConfirmationQuestions { get; set; }
    }
}
