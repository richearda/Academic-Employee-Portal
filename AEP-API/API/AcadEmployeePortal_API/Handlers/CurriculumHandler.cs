using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Handlers
{
    public class CurriculumHandler
    {
        private ICurriculumService _curriculumService;

        public CurriculumHandler(ICurriculumService curriculumService)
        {
            _curriculumService = curriculumService;
        }

        public ValidationResult CanAddCurriculum(Curriculum curriculum)
        {
            ValidationResult result = null;

            if (curriculum.CurriculumName != null && curriculum.CurriculumName != "")
            {
                if (curriculum.ProgramId != 0 && curriculum.ProgramId !< 0)
                {
                    if (curriculum.MajorId != 0 && curriculum.MajorId! < 0)
                    {
                        if (_curriculumService.IsCurriculumExist(curriculum))
                            result = new ValidationResult("Curriculum", "Already existing", 400);
                    }
                    else {
                        result = new ValidationResult("Major ID", "Required", 400);
                    }
                }
                else
                    result = new ValidationResult("Program ID", "Required", 400);
            }
            else
                result = new ValidationResult("Curriculum Name", "Required", 400);

            return result;
        }

        public ValidationResult CanUpdateCurriculum(Curriculum curriculum)
        {
            ValidationResult result = null;
            Curriculum origCurriculum = _curriculumService.GetCurriculum(curriculum.CurriculumId);

            if (origCurriculum != null)
            {
                if (curriculum.CurriculumName == null || curriculum.CurriculumName == "")
                    result = new ValidationResult("Curriculum Name", "Required", 400);
                else if (curriculum.ProgramId == 0 && curriculum.ProgramId < 0)
                    result = new ValidationResult("Program ID is invalid", "Required", 400);
                else if ((curriculum.CurriculumName.Equals(origCurriculum.CurriculumName)))
                {
                    if (_curriculumService.IsCurriculumExist(curriculum))
                        result = new ValidationResult("CurriculumName", "Already existing", 400);
                }
            }
            else
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }

        public ValidationResult CanCheckCurriculum(int ID)
        {
            ValidationResult result = null;
            Curriculum Curriculum = _curriculumService.GetCurriculum(ID);

            if (Curriculum == null)
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }
    }
}
