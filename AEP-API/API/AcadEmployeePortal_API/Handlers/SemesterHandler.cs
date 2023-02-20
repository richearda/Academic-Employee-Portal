using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Handlers
{
    public class SemesterHandler
    {
        private ISemesterService _semesterService;

        public SemesterHandler(ISemesterService semesterService)
        {
            _semesterService = semesterService;
        }

        public ValidationResult CanAddSemester(Semester semester)
        {
            ValidationResult result = null;

            if (semester.SemesterName != null && semester.SemesterName != "")
            {
                if (semester.SemesterCode != null || semester.SemesterCode != null)
                {
                    if (_semesterService.IsSemesterExist(semester))
                        result = new ValidationResult("Semester found", "Already existing", 400);
                }
                else
                    result = new ValidationResult("Semester code is empty", "Required", 400);
            }
            else
                result = new ValidationResult("Semester name is empty", "Required", 400);

            return result;
        }

        public ValidationResult CanUpdateSemester(Semester semester)
        {
            ValidationResult result = null;
            Semester origSemester = _semesterService.GetSemesterById(semester.SemesterId);

            if (origSemester != null)
            {
                if (semester.SemesterName == null || semester.SemesterName == "")
                    result = new ValidationResult("Semester name is empty", "Required", 400);
                else if (semester.SemesterCode == null || semester.SemesterCode == "")
                    result = new ValidationResult("Semester code is empty", "Required", 400);
                else
                {
                    if (_semesterService.IsSemesterExist(semester))
                        result = new ValidationResult("Semester found", "Already existing", 400);
                }
            }
            else
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }

        public ValidationResult CanCheckSemester(int semesterId)
        {
            ValidationResult result = null;
            Semester semester = _semesterService.GetSemesterById(semesterId);

            if (semester == null)
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }
    }
}
