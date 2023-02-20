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

    public class CurriculumService : ICurriculumService
    {

        private EmpPortalDbContext _dbContext;
        private IMapper _mapper;
        public CurriculumService(EmpPortalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public int ActivateCurriculum(int curriculumId)
        {
            Curriculum activateCurriculum = _dbContext.Curricula.AsNoTracking().Where(c => c.CurriculumId == curriculumId).FirstOrDefault();
            activateCurriculum.IsActive = true;
            _dbContext.Entry(activateCurriculum).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int AddCurriculum(Curriculum curriculum)
        {
            _dbContext.Curricula.Add(curriculum);
            return _dbContext.SaveChanges();
        }

        public int DeactivateCurriculum(int curriculumId)
        {
            Curriculum deactivateCurriculum = _dbContext.Curricula.AsNoTracking().Where(c => c.CurriculumId == curriculumId).FirstOrDefault();
            deactivateCurriculum.IsActive = false;
            _dbContext.Entry(deactivateCurriculum).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeleteCurriculum(int curriculumId)
        {
            Curriculum deleteCurriculum = _dbContext.Curricula.AsNoTracking().Where(c => c.CurriculumId == curriculumId).FirstOrDefault();
            _dbContext.Entry(deleteCurriculum).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public Curriculum GetCurriculum(int curriculumId)
        {
            return _dbContext.Curricula.AsNoTracking().Where(c => c.CurriculumId == curriculumId).FirstOrDefault();
        }

        public IQueryable<Curriculum> GetCurricula()
        {
            return _dbContext.Curricula.Where(c => c.IsActive == true);
        }

        public bool IsCurriculumExist(Curriculum curriculum)
        {
            Curriculum curriculumExist = _dbContext.Curricula.Where(c => c.CurriculumId == curriculum.CurriculumId).FirstOrDefault();
            return (curriculumExist != null);
        }

        public int UpdateCurriculum(Curriculum curriculum)
        {
            _dbContext.Entry(curriculum).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public List<CourseDto> GetCurriculumCourses(string curriculumName)
        {
            var curriculum = _dbContext.Curricula.Where(c => c.CurriculumName == curriculumName).FirstOrDefault();
            var courses = _dbContext.CurriculumCourses.Where(c => c.CurriculumId == curriculum.CurriculumId)
                .Include(c => c.Course).Include(c => c.YearLevel).Include(c => c.Semester).OrderBy(c => c.YearLevel);
            return _mapper.Map<List<CourseDto>>(courses);

        }

    }
}
