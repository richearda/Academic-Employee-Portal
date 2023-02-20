using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Handlers
{
    public class CurriculumCourseHandler
    {
        private ICurriculumCourseService _curriculumCourseService;

        public CurriculumCourseHandler(ICurriculumCourseService curriculumCourseService)
        {
            _curriculumCourseService = curriculumCourseService;
        }

        public ValidationResult CanAddCurriculumCourse(CurriculumCourse curriculumCourse)
        {
            ValidationResult result = null;
          
            if (curriculumCourse.CurriculumId != 0 && curriculumCourse.CurriculumId !< 0)
            {
                if (curriculumCourse.YearLevel != 0 && curriculumCourse.YearLevel! > 5)
                {
                    if (curriculumCourse.SemesterId != 0 && curriculumCourse.SemesterId! < 0)
                    {
                        if (curriculumCourse.CourseId != 0 && curriculumCourse.CourseId! < 0)
                        {
                            if (_curriculumCourseService.IsCurriculumCourseExist(curriculumCourse))
                                result = new ValidationResult("Curriculum", "Already existing", 400);
                        }
                        else
                        {
                            result = new ValidationResult("Course ID", "Required", 400);
                        }
                    }
                    else
                    {
                        result = new ValidationResult("Semester", "Required", 400);
                    }
                }
                else
                    result = new ValidationResult("Year Level", "Required", 400);
            }
            else
                result = new ValidationResult("Curriculum", "Required", 400);

            return result;
        }

        public ValidationResult CanUpdateCurriculumCourse(CurriculumCourse curriculumCourse)
        {
            ValidationResult result = null;
            CurriculumCourse origCurriculumCourse = _curriculumCourseService.GetCurriculumCourseById(curriculumCourse.CurriculumCourseId);

            if (origCurriculumCourse != null)
            {
                if (curriculumCourse.CurriculumId == 0 || curriculumCourse.CurriculumId < 0)
                    result = new ValidationResult("Curriculum ID", "Invalid", 400);
                else if (curriculumCourse.YearLevel == 0 || curriculumCourse.YearLevel > 5)
                    result = new ValidationResult("Yea Level", "Invalid", 400);
                else if ((curriculumCourse.CurriculumCourseId.Equals(origCurriculumCourse.CurriculumCourseId)))
                {
                    if (_curriculumCourseService.IsCurriculumCourseExist(curriculumCourse))
                        result = new ValidationResult("Curriculum Course", "Already existing", 400);
                }
            }
            else
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }

        public ValidationResult CanCheckCurriculumCourse(int curriculumId)
        {
            ValidationResult result = null;
            CurriculumCourse CurriculumCourse = _curriculumCourseService.GetCurriculumCourseById(curriculumId);

            if (CurriculumCourse == null)
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }
    }
}
