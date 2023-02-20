using ISMS_API.DTOs;
using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface ICourseScheduleService
    {
        int AddCourseSchedule(CourseSchedule schedule);
        int UpdateCourseSchedule(CourseSchedule schedule);
        int DeleteCourseSchedule(int scheduleID);
        IQueryable<CourseSchedule> GetCourseSchedules();
        CourseSchedule GetCourseScheduleById(int scheduleID);
        int ActivateCourseSchedule(int scheduleID);
        int DeactivateCourseSchedule(int scheduleId);
        bool IsCourseScheduleExist(CourseSchedule schedule);
        ICollection<TeacherCourseSchedulesDto> GetCourseScheduleByTeacher();       
        List<StudentCourseSchedulesDto> GetTeacherCourseMasterList(int courseScheduleId);
        List<StudentCourseSchedulesDto> GetStudentsNotInMasterList(int[] studentId);
        int RemoveStudentFromCourseSchedule(int studentId, int courseScheduleId);
        int RemoveTeacherFromCourseSchedule(int teacherId, int courseScheduleId);
        TeacherCourseSchedule GetCourseScheduleByIdAndTeacherId(int coursescheduleId, int teacherId);
        List<CourseSchedulesDto> GetCourseScheduleByDepartment(int[] departmentId);
        int AddTeacherToCourseSchedule(int teacherId, int courseScheduleId);

        List<StudentDto> GetUnenrolledStudents(int[] studentId);
    }
}
