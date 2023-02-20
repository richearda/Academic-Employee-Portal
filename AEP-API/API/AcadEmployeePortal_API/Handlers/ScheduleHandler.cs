using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Handlers
{
    public class ScheduleHandler
    {
        private ICourseScheduleService _scheduleService;

        public ScheduleHandler(ICourseScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        public ValidationResult CanAddSchedule(CourseSchedule schedule)
        {
            ValidationResult result = null;

            if (schedule.Edpcode != null && schedule.Edpcode != "")
            {
                if (schedule.TimeStart != null || schedule.TimeEnd != null)
                {
                    if (_scheduleService.IsCourseScheduleExist(schedule))
                        result = new ValidationResult("Schedule", "Already existing", 400);
                }
                else
                    result = new ValidationResult("Time start and Time end", "Required", 400);
            }
            else
                result = new ValidationResult("EDP Code is empty", "Required", 400);

            return result;
        }

        public ValidationResult CanUpdateSchedule(CourseSchedule schedule)
        {
            ValidationResult result = null;
            CourseSchedule origschedule = _scheduleService.GetCourseScheduleById(schedule.CourseScheduleId);

            if (origschedule != null)
            {
                if (schedule.Edpcode == null || schedule.Edpcode == "")
                    result = new ValidationResult("EDP Code is empty", "Required", 400);
                else if (schedule.TimeStart == null || schedule.TimeEnd == null)
                    result = new ValidationResult("Time start or time end is empty", "Required", 400);
                else
                {
                    if (_scheduleService.IsCourseScheduleExist(schedule))
                        result = new ValidationResult("The room is existing", "Already existing", 400);
                }
            }
            else
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }

        public ValidationResult CanCheckSchedule(int scheduleId)
        {
            ValidationResult result = null;
            CourseSchedule schedule = _scheduleService.GetCourseScheduleById(scheduleId);

            if (schedule == null)
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }
    }
}
