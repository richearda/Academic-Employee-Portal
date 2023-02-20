using ISMS_API.Data;
using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services
{
    public class TermService : ITermService
    {
        private EmpPortalDbContext _dbContext;
        public TermService(EmpPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int ActivateTerm(int termId)
        {
            Term activateTerm = _dbContext.Terms.AsNoTracking().Where(t => t.TermId == termId).FirstOrDefault();
            activateTerm.IsActive = true;
            _dbContext.Entry(activateTerm).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int AddTerm(Term term)
        {
            _dbContext.Terms.Add(term);
            return _dbContext.SaveChanges();
        }

        public int DeactivateTerm(int termId)
        {
            Term deactivateTerm = _dbContext.Terms.AsNoTracking().Where(t => t.TermId == termId).FirstOrDefault();
            deactivateTerm.IsActive = false;
            _dbContext.Entry(deactivateTerm).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeleteTerm(int termId)
        {
            Term deleteTerm = _dbContext.Terms.AsNoTracking().Where(t => t.TermId == termId).FirstOrDefault();
            _dbContext.Entry(deleteTerm).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public Term GetTermById(int termId)
        {
          return _dbContext.Terms.AsNoTracking().Where(t => t.TermId == termId).FirstOrDefault();
           
        }

        public IQueryable<Term> GetTerms()
        {
            return _dbContext.Terms.Where(t => t.IsActive == true);
        }

        public bool IsTermExist(Term term)
        {
            Term termExist = _dbContext.Terms.Where(t => t.TermId == term.TermId).FirstOrDefault();
            return (termExist != null);
        }

        public int UpdateTerm(Term term)
        {
            _dbContext.Entry(term).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }
    }
}
