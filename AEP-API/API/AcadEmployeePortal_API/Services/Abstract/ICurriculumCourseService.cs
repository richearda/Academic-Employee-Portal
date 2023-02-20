using ISMS_API.DTOs;
using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface ICurriculumCourseService
    {
        int AddCurriculumCourse(CurriculumCourse curriculumCourse);
        int UpdateCurriculumCourse(CurriculumCourse curriculumCourse);
        int DeleteCurriculumCourse(int curriculumCourseId);       
        CurriculumCourse GetCurriculumCourseById(int curriculumCourseId);       
        bool IsCurriculumCourseExist(CurriculumCourse curriculumCourse);
        List<CurriculumCourseDto> GetCurriculumCourses();
        List<CurriculumCourseDto> GetCoursesByCurriculum(string curriculumName);
    }
}
