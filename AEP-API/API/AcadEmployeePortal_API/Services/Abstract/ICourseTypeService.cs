using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface ICourseTypeService
    {
        IQueryable<CourseType> GetCourseTypes();
        int AddCourseType(CourseType CourseType);
        int UpdateCourseType(CourseType CourseType);
        int ActivateCourseType(int ID);
        int DeactivateCourseType(int ID);
        int DeleteCourseType(int ID);
        bool IsCourseTypeExist(CourseType CourseType);
        CourseType GetCourseType(int ID);

    }
}
