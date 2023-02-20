using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface ISemesterService
    {
        IQueryable<Semester> GetSemesters();
        int AddSemester(Semester semester);
        int UpdateSemester(Semester semester);
        int ActivateSemester(int semesterId);
        int DeactivateSemester(int semesterId);
        int DeleteSemester(int semesterId);
        bool IsSemesterExist(Semester semester);
        Semester GetSemesterById(int semesterId);
    }
}
