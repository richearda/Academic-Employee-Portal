using ISMS_API.Data;
using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services
{
    public class StudentGradesService : IStudentGradesService
    {
        private EmpPortalDbContext _dbContext;
        public StudentGradesService(EmpPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int AddStudentGrades(StudentGrades studentGrades)
        {
            _dbContext.StudentGrades.Add(studentGrades);
            return _dbContext.SaveChanges();
        }

        public int DeleteStudentGrades(int studentGradesId)
        {
            StudentGrades deleteGrades = _dbContext.StudentGrades.AsNoTracking().Where(g => g.StudentGradesID == studentGradesId).FirstOrDefault();
            _dbContext.Entry(deleteGrades).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public StudentGrades GetStudentGradesById(int studentGradesId)
        {
            return _dbContext.StudentGrades.AsNoTracking().Where(g => g.StudentGradesID == studentGradesId).FirstOrDefault();
        }

        public IQueryable<StudentGrades> GetStudentGrades()
        {
            return _dbContext.StudentGrades;
        }

        public bool IsStudentGradesExist(StudentGrades studentGrades)
        {
            StudentGrades checkGrades = _dbContext.StudentGrades.Where(g => g.StudentGradesID == studentGrades.StudentGradesID).FirstOrDefault();          
            return (checkGrades != null);
        }

        public int UpdateStudentGrades(StudentGrades studentGrades)
        {
            _dbContext.Entry(studentGrades).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }
    }
}
