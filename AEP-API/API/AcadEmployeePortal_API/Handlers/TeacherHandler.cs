using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Handlers
{
    public class TeacherHandler
    {
        private ITeacherService _teacherService;

        public TeacherHandler(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        public ValidationResult CanAddTeacher(Teacher teacher)
        {
            ValidationResult result = null;

            if (teacher.PersonId != null && teacher.PersonId !< 0)
            {
                if (teacher.CollegeId != null && teacher.CollegeId !< 0)
                {
                    if (_teacherService.IsTeacherExist(teacher))
                        result = new ValidationResult("Teacher", "Already existing", 400);
                }
                else
                    result = new ValidationResult("College ID", "Required", 400);
            }
            else
                result = new ValidationResult("Person ID", "Required", 400);

            return result;
        }

        public ValidationResult CanUpdateTeacher(Teacher teacher)
        {
            ValidationResult result = null;
            Teacher origTeacher = _teacherService.GetTeacherById(teacher.TeacherId);

            if (origTeacher != null)
            {
                if (teacher.PersonId == null || teacher.PersonId == 0)
                    result = new ValidationResult("Person ID", "Required", 400);
                else if (teacher.CollegeId == null || teacher.CollegeId !< 0)
                    result = new ValidationResult("College ID", "Required", 400);
                else
                {
                    if (_teacherService.IsTeacherExist(teacher))
                        result = new ValidationResult("Teacher", "Already existing", 400);
                }
            }
            else
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }

        public ValidationResult CanCheckTeacher(int teacherId)
        {
            ValidationResult result = null;
            Teacher Teacher = _teacherService.GetTeacherById(teacherId);

            if (Teacher == null)
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }
    }
}
