using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Handlers
{
    public class StudentScheduleHandler
    {
        private IStudentCourseScheduleService _studentService;

        public StudentScheduleHandler(IStudentCourseScheduleService studentService)
        {
            _studentService = studentService;
        }

        public ValidationResult CanAddStudentSchedule(StudentCourseSchedule studentSchedule)
        {
            ValidationResult result = null;

            if (studentSchedule.StudentId != null && studentSchedule.StudentId !< 0)
            {
                if (studentSchedule.CourseScheduleId != null && studentSchedule.CourseScheduleId !< 0)
                {
                    if (_studentService.IsStudentScheduleExist(studentSchedule))
                        result = new ValidationResult("StudentScheduleName", "Already existing", 400);
                }
                else
                    result = new ValidationResult("Schedule ID", "Required", 400);
            }
            else
                result = new ValidationResult("Student ID", "Required", 400);

            return result;
        }

        public ValidationResult CanUpdateStudentSchedule(StudentCourseSchedule studentSchedule)
        {
            ValidationResult result = null;
            StudentCourseSchedule origStudentSchedule = _studentService.GetStudentSchedule(studentSchedule.StudentCourseScheduleId);

            if (origStudentSchedule != null)
            {
                if (studentSchedule.StudentId == null || studentSchedule.StudentId == 0)
                    result = new ValidationResult("Student ID", "Required", 400);
                else if (studentSchedule.CourseScheduleId == null || studentSchedule.CourseScheduleId == 0)
                    result = new ValidationResult("Schedule ID", "Required", 400);
                else
                {
                    if (_studentService.IsStudentScheduleExist(studentSchedule))
                        result = new ValidationResult("Student Schedule", "Already existing", 400);
                }
            }
            else
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }

        public ValidationResult CanCheckStudentSchedule(int studentScheduleId)
        {
            ValidationResult result = null;
            StudentCourseSchedule StudentSchedule = _studentService.GetStudentSchedule(studentScheduleId);

            if (StudentSchedule == null)
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }




    }
}
