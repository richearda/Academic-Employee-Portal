using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Handlers
{
    public class TermHandler
    {
        private ITermService _termService;

        public TermHandler(ITermService termService)
        {
            _termService = termService;
        }

        public ValidationResult CanAddTerm(Term term)
        {
            ValidationResult result = null;

            if (term.TermName != null && term.TermName != "")
            {
                if (term.TermCode != null && term.TermCode != "")
                {
                    if (_termService.IsTermExist(term))
                        result = new ValidationResult("Term", "Already existing", 400);
                }
                else
                    result = new ValidationResult("Term Code", "Required", 400);
            }
            else
                result = new ValidationResult("Term Name", "Required", 400);

            return result;
        }

        public ValidationResult CanUpdateTerm(Term term)
        {
            ValidationResult result = null;
            Term origTerm = _termService.GetTermById(term.TermId);

            if (origTerm != null)
            {
                if (term.TermName == null || term.TermName == "")
                    result = new ValidationResult("Term Name", "Required", 400);
                else if (term.TermCode == null || term.TermCode == "")
                    result = new ValidationResult("Term Code", "Required", 400);
                else 
                {
                    if (_termService.IsTermExist(term))
                        result = new ValidationResult("TermName", "Already existing", 400);
                }
            }
            else
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }

        public ValidationResult CanCheckTerm(int ID)
        {
            ValidationResult result = null;
            Term Term = _termService.GetTermById(ID);

            if (Term == null)
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }
    }
}
