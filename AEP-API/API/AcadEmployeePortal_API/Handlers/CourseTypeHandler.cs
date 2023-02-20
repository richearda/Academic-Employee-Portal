using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Handlers
{
    public class CourseTypeHandler
    {
        private ICourseTypeService _courseTypeService;

        public CourseTypeHandler(ICourseTypeService CourseTypeService)
        {
            _courseTypeService = CourseTypeService;
        }

        public ValidationResult CanAddCourseType(CourseType courseType)
        {
            ValidationResult result = null;

            if (courseType.CourseTypeName != null && courseType.CourseTypeName != "")
            {
                if (courseType.CourseTypeDescription != null && courseType.CourseTypeDescription != "")
                {
                    if (_courseTypeService.IsCourseTypeExist(courseType))
                        result = new ValidationResult("Course Type Name", "Already existing", 400);
                }
                else
                    result = new ValidationResult("Course Type Description", "Required", 400);
            }
            else
                result = new ValidationResult("Course Type Name", "Required", 400);

            return result;
        }

        public ValidationResult CanUpdateCourseType(CourseType courseType)
        {
            ValidationResult result = null;
            CourseType toUpdateCourseType = _courseTypeService.GetCourseType(courseType.CourseTypeID);

            if (toUpdateCourseType != null)
            {
                if (courseType.CourseTypeName == null || courseType.CourseTypeName == "")
                    result = new ValidationResult("Course Type Name", "Required", 400);
                else if (courseType.CourseTypeDescription == null || courseType.CourseTypeDescription == "")
                    result = new ValidationResult("Course Type Description", "Required", 400);
                else if ((courseType.CourseTypeName.Equals(toUpdateCourseType.CourseTypeName, StringComparison.OrdinalIgnoreCase) && courseType.CourseTypeDescription.Equals(toUpdateCourseType.CourseTypeDescription, StringComparison.OrdinalIgnoreCase)))
                 result = new ValidationResult("Please provide different value.", "Cannot update with the same value.", 400);
                else
                {  
                    if (_courseTypeService.IsCourseTypeExist(courseType))
                        result = new ValidationResult("Course Type", "Already existing", 400);
                }
            }
            else
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }

        public ValidationResult CanCheckCourseType(int courseTypeId)
        {
            ValidationResult result = null;
            CourseType courseType = _courseTypeService.GetCourseType(courseTypeId);

            if (courseType == null)
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }
    }

}

