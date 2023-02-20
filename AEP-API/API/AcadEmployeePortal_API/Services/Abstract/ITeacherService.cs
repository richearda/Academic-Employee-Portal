using ISMS_API.DTOs;
using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ISMS_API.Services.Abstract
{
    public interface ITeacherService
    {
        int AddTeacher(Teacher teacherDto);
        int UpdateTeacher(Teacher teacher);
        int DeleteTeacher(int teacherId);
        ICollection<TeacherDto> GetTeachers();
       ICollection<TeacherDto> GetTeachersByCollege(string collegeName);
        Teacher GetTeacherById(int teacherId);
        int ActivateTeacher(int teacherId);
        int DeactivateTeacher(int teacherId);
        bool IsTeacherExist(Teacher teacher);
        //List<CourseSchedulesDto> GetTeacherCourseSchedules(int teacherId);
        TeacherDto GetTeacherDetails(int teacherId);
        TeacherDto GetTeacherByPersonId(int personId);
    }
}
