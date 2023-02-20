using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Handlers
{
    public class CourseHandler
    {
        private ICourseService _CourseService;

        public CourseHandler(ICourseService CourseService)
        {
            _CourseService = CourseService;
        }

        public ValidationResult CanAddCourse(Course Course)
        {
            ValidationResult result = null;

            if (Course.CourseCode != null && Course.CourseCode != "")
            {
                if (Course.CourseCode != null && Course.CourseCode != "")
                {
                    if (_CourseService.IsCourseExist(Course))
                        result = new ValidationResult("CourseName", "Already existing", 400);
                }
                else
                    result = new ValidationResult("CourseCode", "Required", 400);
            }
            else
                result = new ValidationResult("CourseName", "Required", 400);

            return result;
        }

        public ValidationResult CanUpdateCourse(Course Course)
        {
            ValidationResult result = null;
            Course origCourse = _CourseService.GetCourse(Course.CourseID);

            if (origCourse != null)
            {
                if (Course.CourseCode == null || Course.CourseCode == "")
                    result = new ValidationResult("CourseCode", "Required", 400);
                else if (Course.CourseDescription == null || Course.CourseDescription == "")
                    result = new ValidationResult("CourseDescription", "Required", 400);
                else if ((Course.CourseCode.Equals(origCourse.CourseCode)))
                {
                    if (_CourseService.IsCourseExist(Course))
                        result = new ValidationResult("CourseName", "Already existing", 400);
                }
            }
            else
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }

        public ValidationResult CanCheckCourse(int ID)
        {
            ValidationResult result = null;
            Course Course = _CourseService.GetCourse(ID);

            if (Course == null)
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }



    }
}
