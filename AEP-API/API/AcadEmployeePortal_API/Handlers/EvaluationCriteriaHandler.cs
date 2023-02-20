using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Handlers
{
    public class EvaluationCriteriaHandler
    {
        private IEvaluationCriteriaService _evaluationCriteriaService;

        public EvaluationCriteriaHandler(IEvaluationCriteriaService evaluationCriteriaService)
        {
            _evaluationCriteriaService = evaluationCriteriaService;
        }

        public ValidationResult CanAddEvaluationCriteria(EvaluationCriteria evaluationCriteria)
        {
            ValidationResult result = null;

            if (evaluationCriteria.EvaluationCriteriaDescription != null && evaluationCriteria.EvaluationCriteriaDescription != "")
            {


                if (_evaluationCriteriaService.IsCriteriaExist(evaluationCriteria))
                {
                    result = new ValidationResult("Evaluation Criteria", "Already existing", 400);
                }
            }
            else
                result = new ValidationResult("Evaluation Description", "Required", 400);

            return result;
        }

        public ValidationResult CanUpdateEvaluationCriteria(EvaluationCriteria evaluationCriteria)
        {
            ValidationResult result = null;
            EvaluationCriteria eCriteria = _evaluationCriteriaService.GetEvaluationCriteria(evaluationCriteria.EvaluationCriteriaID);

            if (eCriteria != null)
            {
                if (evaluationCriteria.EvaluationCriteriaDescription == null || evaluationCriteria.EvaluationCriteriaDescription == "")
                    result = new ValidationResult("Criteria Description", "Required", 400);
                else if ((evaluationCriteria.EvaluationCriteriaDescription.Equals(eCriteria.EvaluationCriteriaDescription)))
                {
                    if (_evaluationCriteriaService.IsCriteriaExist(evaluationCriteria))
                        result = new ValidationResult("Criteria Description", "Already existing", 400);
                }
            }
            else
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }

        public ValidationResult CanCheckEvaluationCriteria(int ID)
        {
            ValidationResult result = null;
            EvaluationCriteria evaluationCriteria = _evaluationCriteriaService.GetEvaluationCriteria(ID);

            if (evaluationCriteria == null)
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }
    }
}
