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
    public class StudentCourseScheduleService : IStudentCourseScheduleService
    {
        private EmpPortalDbContext _dbContext;
        public StudentCourseScheduleService(EmpPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int ActivateStudentSchedule(int studentScheduleId)
        {
            StudentCourseSchedule activateSchedule = _dbContext.StudentCourseSchedules.AsNoTracking().Where(s => s.StudentCourseScheduleId == studentScheduleId).FirstOrDefault();
            activateSchedule.IsActive = true;
            _dbContext.Entry(activateSchedule).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int AddStudentSchedule(StudentCourseSchedule studentSchedule)
        {
            _dbContext.StudentCourseSchedules.Add(studentSchedule);
            return _dbContext.SaveChanges();
        }
        public int AddStudentSchedule(int studentId, int courseScheduleId)
        {
            var student = _dbContext.Students.Where(s => s.StudentID == studentId).FirstOrDefault();
            var courseSchedule = _dbContext.CourseSchedules.Where(cs => cs.CourseScheduleId == courseScheduleId).FirstOrDefault();
            var studentSchedule = new StudentCourseSchedule {
                StudentId = student.StudentID,
                Student = student,
                CourseScheduleId = courseSchedule.CourseScheduleId,
                CourseSchedules = courseSchedule,
                IsActive = true            
            };
            _dbContext.StudentCourseSchedules.Add(studentSchedule);
            return _dbContext.SaveChanges();
        }


        public int DeactivateStudentSchedule(int studentScheduleId)
        {
            StudentCourseSchedule deactivateSchedule = _dbContext.StudentCourseSchedules.AsNoTracking().Where(s => s.StudentCourseScheduleId == studentScheduleId).FirstOrDefault();
            deactivateSchedule.IsActive = false;
            _dbContext.Entry(deactivateSchedule).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeleteStudentSchedule(int studentScheduleId)
        {
            StudentCourseSchedule deleteSched = _dbContext.StudentCourseSchedules.AsNoTracking().Where(s => s.StudentCourseScheduleId == studentScheduleId).FirstOrDefault();
            _dbContext.Entry(deleteSched).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public StudentCourseSchedule GetStudentSchedule(int studentScheduleId)
        {
            return _dbContext.StudentCourseSchedules.AsNoTracking().Where(s => s.StudentCourseScheduleId == studentScheduleId).FirstOrDefault();
        }

        public IQueryable<StudentCourseSchedule> GetStudentSchedules()
        {
            return _dbContext.StudentCourseSchedules.Where(s => s.IsActive == true);
        }

        public bool IsStudentScheduleExist(StudentCourseSchedule studentSchedule)
        {
            StudentCourseSchedule checkSchedule = _dbContext.StudentCourseSchedules.Where(s => s.StudentCourseScheduleId == studentSchedule.StudentCourseScheduleId).FirstOrDefault();
            return (checkSchedule != null);
        }

        public int UpdateStudentSchedule(StudentCourseSchedule studentSchedule)
        {        
            _dbContext.Entry(studentSchedule).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public StudentCourseSchedule GetStudentCourseSchedule(int studentId)
        {
            return _dbContext.StudentCourseSchedules.Include(cs => cs.CourseSchedules).Where(ss => ss.StudentId == studentId).FirstOrDefault();
            
        }
    }
}
