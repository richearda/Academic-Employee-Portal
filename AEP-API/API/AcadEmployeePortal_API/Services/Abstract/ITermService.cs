using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface ITermService
    {
        int AddTerm(Term term);
        int UpdateTerm(Term term);
        int DeleteTerm(int termId);
        IQueryable<Term> GetTerms();
        Term GetTermById(int termId);
        int ActivateTerm(int termId);
        int DeactivateTerm(int termId);
        bool IsTermExist(Term term);
    }
}
