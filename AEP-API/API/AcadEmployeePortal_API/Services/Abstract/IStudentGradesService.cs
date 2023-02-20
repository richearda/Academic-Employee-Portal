using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface IStudentGradesService
    {
        int AddStudentGrades(StudentGrades studentGrades);
        int UpdateStudentGrades(StudentGrades studentGrades);
        int DeleteStudentGrades(int studentGradesId);
        IQueryable<StudentGrades> GetStudentGrades();
        StudentGrades GetStudentGradesById(int studentGradesId);
        bool IsStudentGradesExist(StudentGrades StudentGrades);

    }
}
