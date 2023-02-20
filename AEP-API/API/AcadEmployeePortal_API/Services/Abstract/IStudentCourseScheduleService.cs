using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface IStudentCourseScheduleService
    {
        int AddStudentSchedule(StudentCourseSchedule studentSchedule);
        int UpdateStudentSchedule(StudentCourseSchedule studentSchedule);
        int DeleteStudentSchedule(int studentScheduleId);
        IQueryable<StudentCourseSchedule> GetStudentSchedules();
        StudentCourseSchedule GetStudentSchedule(int studentScheduleId);
        int ActivateStudentSchedule(int ID);
        int DeactivateStudentSchedule(int ID);
        bool IsStudentScheduleExist(StudentCourseSchedule StudentSchedule);
        int AddStudentSchedule(int studentId, int courseScheduleId);
        StudentCourseSchedule GetStudentCourseSchedule(int studentId);
    }
}
