using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface IEvaluationCriteriaService
    {
        int AddEvaluationCriteria(EvaluationCriteria eCriteria);
        int UpdateEvaluationCriteria(EvaluationCriteria eCriteria);
        int DeleteEvaluationCriteria(int criteriaId);
        EvaluationCriteria GetEvaluationCriteria(int criteriaId);
        IQueryable<EvaluationCriteria> GetEvaluationCriterion();
        bool IsCriteriaExist(EvaluationCriteria eCriteria);
        int ActivateEvaluationCriteria(int criteriaId);
        int DeactivateEvaluationCriteria(int criteriaId);

    }
}
