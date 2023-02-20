using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Handlers
{
    public class TeacherCourseScheduleHandler
    {
        private ITeacherCourseScheduleService _teacherScheduleService;

        public TeacherCourseScheduleHandler(ITeacherCourseScheduleService teacherScheduleService)
        {
            _teacherScheduleService = teacherScheduleService;
        }

        public ValidationResult CanAddTeacherSchedule(Teacher teacher, CourseSchedule courseSchedule)
        {
            ValidationResult result = null;

            if (teacher != null && courseSchedule != null)
            {           
                    if (_teacherScheduleService.IsTeacherScheduleExist(teacher, courseSchedule))
                        result = new ValidationResult("Teacher Schedule", "Already existing", 400);              
            }
            else
                result = new ValidationResult("Teacher ID and Course Schedule ID is required.", "Required", 400);

            return result;
        }

        public ValidationResult CanUpdateTeacherSchedule(Teacher teacher, CourseSchedule courseSchedule)
        {
            ValidationResult result = null;
            TeacherCourseSchedule origTeacherSchedule = _teacherScheduleService.GetTeacherScheduleById(teacher.TeacherId);

            if (origTeacherSchedule != null)
            {
                if (teacher.TeacherId <= 0)
                    result = new ValidationResult("Teacher ID", "Required", 400);
                else if (courseSchedule.CourseScheduleId == 0)
                    result = new ValidationResult("Schedule ID", "Required", 400);
                else
                {
                    if (_teacherScheduleService.IsTeacherScheduleExist(teacher, courseSchedule))
                        result = new ValidationResult("TeacherScheduleName", "Already existing", 400);
                }
            }
            else
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }

        public ValidationResult CanCheckTeacherSchedule(int teacherScheduleId)
        {
            ValidationResult result = null;
            TeacherCourseSchedule TeacherSchedule = _teacherScheduleService.GetTeacherScheduleById(teacherScheduleId);

            if (TeacherSchedule == null)
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }
    }
}
