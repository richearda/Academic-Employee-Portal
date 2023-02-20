using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Handlers
{
    public class StudentGradesHandler
    {
        private IStudentGradesService _studentGradesService;

        public StudentGradesHandler(IStudentGradesService studentGradesService)
        {
            _studentGradesService = studentGradesService;
        }

        public ValidationResult CanAddStudentGrades(StudentGrades studentGrades)
        {
            ValidationResult result = null;


            if (studentGrades.PrelimPeriodGrade == null)
            {
                result = new ValidationResult("Student does not have prelim grade.", "Required", 400);
            }
            else if (studentGrades.MidtermPeriodGrade == null)
            {
                result = new ValidationResult("Student does not have midterm grade.", "Required", 400);
            }
            else if (studentGrades.SemiFinalPeriodGrade == null)
            {
                result = new ValidationResult("Student does not have semi-final grade.", "Required", 400);
            }
            else if (studentGrades.FinalPeriodGrade == null)
            {
                result = new ValidationResult("Student does not have final grade.", "Required", 400);
            }
            else if (studentGrades.FinalGeneralAverage == null && studentGrades.GradeRemarksId == null)
            {
                result = new ValidationResult("Student does not have final average grade.", "Required", 400);
            }
            return result;

        }

        public ValidationResult CanUpdateStudentGrades(StudentGrades studentGrades)
        {
            ValidationResult result = null;
            StudentGrades origStudentGrades = _studentGradesService.GetStudentGradesById(studentGrades.StudentGradesID);

            if (origStudentGrades != null)
            {
                if (studentGrades.PrelimPeriodGrade == null)
                    result = new ValidationResult("Student does not have prelim grade", "Can not update.", 400);
                else if (studentGrades.MidtermPeriodGrade == null)
                    result = new ValidationResult("Student does not have midterm grade", "Can not update.", 400);
                else if (studentGrades.SemiFinalPeriodGrade == null)
                    result = new ValidationResult("Student does not have semi-final grade", "Can not update.", 400);
                else if (studentGrades.FinalPeriodGrade == null)
                    result = new ValidationResult("Student does not have final grade", "Can not update.", 400);
                else if (studentGrades.FinalGeneralAverage == null)
                    result = new ValidationResult("Student does not have final average grade", "Can not update.", 400);
                else
                {
                    if (_studentGradesService.IsStudentGradesExist(studentGrades))
                        result = new ValidationResult("StudentGrades found", "Already existing", 400);
                }
            }
            else
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }

        public ValidationResult CanCheckStudentGrades(int StudentGradesId)
        {
            ValidationResult result = null;
            StudentGrades StudentGrades = _studentGradesService.GetStudentGradesById(StudentGradesId);

            if (StudentGrades == null)
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }
    }
}
