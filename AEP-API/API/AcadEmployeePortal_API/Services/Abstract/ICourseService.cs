using System;
using System.Collections.Generic;
using System.Linq;
using ISMS_API.Models;
using System.Threading.Tasks;
using ISMS_API.DTOs;

namespace ISMS_API.Services.Abstract
{
    public interface ICourseService
    {
        Task<List<CourseDto>> GetCourses();
        //Task<List<CourseDto>> GetCoursesByTeacherId(int teacherId);
        int AddCourse(Course Course);
        int UpdateCourse(Course Course);
        int ActivateCourse(int ID);
        int DeactivateCourse(int ID);
        int DeleteCourse(int ID);
        bool IsCourseExist(Course Course);
        Course GetCourse(int ID);
        List<CourseDto> GetCourseByTeacherId(int teacherId);

        //CourseDto GetCourseSchedules(int courseId);
    }
}
