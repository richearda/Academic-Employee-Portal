using ISMS_API.DTOs;
using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface ITeacherCourseScheduleService
    {
        int AddTeacherSchedule (Teacher teacher, CourseSchedule courseSchedule);
        int UpdateTeacherSchedule(Teacher teacher, CourseSchedule courseSchedule);
        int DeleteTeacherSchedule(int teacherScheduleId);
        IQueryable<TeacherCourseSchedule> GetTeacherSchedules();
        TeacherCourseSchedule GetTeacherScheduleById(int teacherScheduleId);
        int ActivateTeacherSchedule(int teacherScheduleId);
        int DeactivateTeacherSchedule(int teacherScheduleId);
        bool IsTeacherScheduleExist(Teacher teacher, CourseSchedule courseSchedule);       
        List<TeacherCourseSchedulesDto> GetCourseSchedulesByTeacherId(int teacherId);
        List<TeacherCourseSchedulesDto> GetCoursesNotInTeacherList(int[] courseSchedIds);

    }
}
