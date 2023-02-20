using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Handlers
{
    public class GradeRemarksHandler
    {
        private IGradeRemarksService _gradeRemarksService;

        public GradeRemarksHandler(IGradeRemarksService gradeRemarksService)
        {
            _gradeRemarksService = gradeRemarksService;
        }

        public ValidationResult CanAddGradeRemarks(GradeRemarks gradeRemarks)
        {
            ValidationResult result = null;

            if (gradeRemarks.GradeRemarksDescription != null && gradeRemarks.GradeRemarksDescription != "")
            {
                if (gradeRemarks.GradeRemarksCode != null && gradeRemarks.GradeRemarksCode != "")
                {
                    if (_gradeRemarksService.IsGradeRemarksExist(gradeRemarks))
                        result = new ValidationResult("Grade Remarks", "Already existing", 400);
                }
                else
                    result = new ValidationResult("Grade Remarks Code", "Required", 400);
            }
            else
                result = new ValidationResult("Grade Remarks Name", "Required", 400);

            return result;
        }

        public ValidationResult CanUpdateGradeRemarks(GradeRemarks gradeRemarks)
        {
            ValidationResult result = null;
            GradeRemarks origGradeRemarks = _gradeRemarksService.GetGradeRemarksById(gradeRemarks.GradeRemarksID);

            if (origGradeRemarks != null)
            {
                if (gradeRemarks.GradeRemarksDescription == null || gradeRemarks.GradeRemarksDescription == "")
                    result = new ValidationResult("Grade Remarks Description", "Required", 400);
                else if (gradeRemarks.GradeRemarksCode == null || gradeRemarks.GradeRemarksCode == "")
                    result = new ValidationResult("Grade Remarks Code", "Required", 400);
                else if(!(gradeRemarks.GradeRemarksDescription.Equals(origGradeRemarks.GradeRemarksDescription) && (gradeRemarks.GradeRemarksCode.Equals(origGradeRemarks.GradeRemarksCode))))
                {
                    if (_gradeRemarksService.IsGradeRemarksExist(gradeRemarks))
                        result = new ValidationResult("Grade Remarks", "Already existing", 400);
                }
            }
            else
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }

        public ValidationResult CanCheckGradeRemarks(int GradeRemarksId)
        {
            ValidationResult result = null;
            GradeRemarks gradeRemarks = _gradeRemarksService.GetGradeRemarksById(GradeRemarksId);

            if (gradeRemarks == null)
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }
    }
}
