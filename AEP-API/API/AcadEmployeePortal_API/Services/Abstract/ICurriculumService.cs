using ISMS_API.DTOs;
using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface ICurriculumService
    {
        IQueryable<Curriculum> GetCurricula();
        int AddCurriculum(Curriculum curriculum);
        int UpdateCurriculum(Curriculum curriculum);
        int ActivateCurriculum(int curriculumId);
        int DeactivateCurriculum(int curriculumId);
        int DeleteCurriculum(int curriculumId);
        bool IsCurriculumExist(Curriculum curriculum);
        Curriculum GetCurriculum(int curriculumId);
        List<CourseDto> GetCurriculumCourses(string curriculumName);
    }
}
