using AutoMapper;
using ISMS_API.Data;
using ISMS_API.DTOs;
using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services
{
    public class CurriculumCourseService : ICurriculumCourseService
    {
        private EmpPortalDbContext _dbContext;
        private IMapper _mapper;
        public CurriculumCourseService(EmpPortalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public int AddCurriculumCourse(CurriculumCourse curriculumCourse)
        {
            _dbContext.CurriculumCourses.Add(curriculumCourse);
            return _dbContext.SaveChanges();
        }

        public int DeleteCurriculumCourse(int curriculumCourseId)
        {
            CurriculumCourse toDelete = _dbContext.CurriculumCourses.AsNoTracking().Where(c => c.CurriculumCourseId == curriculumCourseId).FirstOrDefault();
            _dbContext.Entry(toDelete).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public CurriculumCourse GetCurriculumCourseById(int curriculumCourseId)
        {
            return _dbContext.CurriculumCourses.AsNoTracking().Where(c => c.CurriculumCourseId == curriculumCourseId).FirstOrDefault();
        }

        public List<CurriculumCourseDto> GetCurriculumCourses()
        {
            var courses = _dbContext.CurriculumCourses.Include(c => c.Course).ThenInclude(cc => cc.CourseType).OrderBy(c => c.Curriculum).ToList();
            return _mapper.Map<List<CurriculumCourseDto>>(courses);
        }
        public List<CurriculumCourseDto> GetCoursesByCurriculum(string curriculumName)
        {
            var courses = _dbContext.CurriculumCourses.Include(c => c.Course).ThenInclude(cc => cc.CourseType).Where(cc => cc.Curriculum.CurriculumName == curriculumName).ToList();
            return _mapper.Map<List<CurriculumCourseDto>>(courses);
        }

        public bool IsCurriculumCourseExist(CurriculumCourse curriculumCourse)
        {
            CurriculumCourse isExist = _dbContext.CurriculumCourses.Where(c => c.CurriculumCourseId == curriculumCourse.CurriculumCourseId).FirstOrDefault();
            return (isExist != null);
        }

        public int UpdateCurriculumCourse(CurriculumCourse curriculumCourse)
        {
            _dbContext.Entry(curriculumCourse).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }
       
        //public List<CourseDto> GetCurriculumCourses()
        //{ 
        
        //}
    }
}
