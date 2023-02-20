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
    public class EvaluationCriteriaService:IEvaluationCriteriaService
    {
        private EmpPortalDbContext _dbContext;
        public EvaluationCriteriaService(EmpPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int ActivateEvaluationCriteria(int criteriaId)
        {
            EvaluationCriteria toActivate = _dbContext.EvaluationCriterion.Where(c => c.EvaluationCriteriaID == criteriaId).FirstOrDefault();
            toActivate.IsActive = true;
            _dbContext.Entry(toActivate).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int AddEvaluationCriteria(EvaluationCriteria eCriteria)
        {
            _dbContext.EvaluationCriterion.Add(eCriteria);
            return _dbContext.SaveChanges();
        }

        public int DeactivateEvaluationCriteria(int criteriaId)
        {
            EvaluationCriteria toDeactivate = _dbContext.EvaluationCriterion.Where(c => c.EvaluationCriteriaID == criteriaId).FirstOrDefault();
            toDeactivate.IsActive = false;
            _dbContext.Entry(toDeactivate).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeleteEvaluationCriteria(int criteriaId)
        {
            EvaluationCriteria toDelete = _dbContext.EvaluationCriterion.Where(c => c.EvaluationCriteriaID == criteriaId).FirstOrDefault();
            _dbContext.Entry(toDelete).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public EvaluationCriteria GetEvaluationCriteria(int criteriaId)
        {
            return _dbContext.EvaluationCriterion.AsNoTracking().Where(c => c.EvaluationCriteriaID == criteriaId).FirstOrDefault();
        }

        public IQueryable<EvaluationCriteria> GetEvaluationCriterion()
        {
            return _dbContext.EvaluationCriterion.Where(c => c.IsActive == true);
        }

        public bool IsCriteriaExist(EvaluationCriteria eCriteria)
        {
            EvaluationCriteria isCriteriaExist = _dbContext.EvaluationCriterion.Where(c => c.EvaluationCriteriaDescription == eCriteria.EvaluationCriteriaDescription).FirstOrDefault();
            return (isCriteriaExist != null); ;
        }

        public int UpdateEvaluationCriteria(EvaluationCriteria eCriteria)
        {
            _dbContext.Entry(eCriteria).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }
    }
}
