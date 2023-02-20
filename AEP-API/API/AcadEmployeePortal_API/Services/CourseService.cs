using System;
using ISMS_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ISMS_API.Services.Abstract;
using ISMS_API.Data;
using Microsoft.EntityFrameworkCore;
using ISMS_API.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace ISMS_API.Services
{
    public class CourseService : ICourseService
    {
        private EmpPortalDbContext _dbContext;
        private IMapper _mapper;
        public CourseService(EmpPortalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        

        public int AddCourse(Course Course)
        {
            _dbContext.Courses.Add(Course);
            return _dbContext.SaveChanges();
        }

        public int DeactivateCourse(int ID)
        {
            Course toDeactivate = _dbContext.Courses.AsNoTracking().Where(c => c.CourseID == ID).FirstOrDefault();
            //update IsActive
            toDeactivate.IsActive = false;
            _dbContext.Entry(toDeactivate).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int ActivateCourse(int ID)
        {
            Course toActivate = _dbContext.Courses.AsNoTracking().Where(c => c.CourseID == ID).FirstOrDefault();
            //update IsActive
            toActivate.IsActive = true;
            _dbContext.Entry(toActivate).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeleteCourse(int ID)
        {
            Course toDelete = _dbContext.Courses.AsNoTracking().Where(c => c.CourseID == ID).FirstOrDefault();
            _dbContext.Entry(toDelete).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public Course GetCourse(int ID)
        {
            return _dbContext.Courses.AsNoTracking().Where(c => c.CourseID == ID).FirstOrDefault();
        }

        public async Task<List<CourseDto>> GetCourses()
        {
            //var course = await _dbContext.Courses.ToListAsync();
            //var courseSchedules = _dbContext.CourseSchedules.Where(s => s.CourseId == cours)
            var courseSchedules =
                //await _dbContext.Courses.ProjectTo<CourseDto>(_mapper.ConfigurationProvider).ToListAsync();
            await _dbContext.Courses.Include(c => c.CourseType)
                .Include(c => c.Schedule)
                    .ThenInclude(c => c.Day)
                .Include(c => c.Schedule)
                    .ThenInclude(c => c.MidDayTimeStart)
                .Include(c => c.Schedule)
                   .ThenInclude(c => c.MidDayTimeEnd)
                 .Include(c => c.Schedule).ToListAsync();

            return _mapper.Map<List<CourseDto>>(courseSchedules);
            //return await _dbContext.Courses.ProjectTo<CourseDto>(_mapper.ConfigurationProvider).ToListAsync();



        }

        public bool IsCourseExist(Course Course)
        {
            Course toCheck = _dbContext.Courses.Where(c => c.CourseCode == Course.CourseCode).FirstOrDefault();
            return (toCheck != null);
        }

        public int UpdateCourse(Course Course)
        {
            _dbContext.Entry(Course).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public List<CourseDto> GetCourseByTeacherId(int teacherId)
        {
            var courses = _dbContext.TeacherCourseSchedules.Where(c => c.TeacherId == teacherId).Include(c => c.CourseSchedule.Course);
            //_dbContext.Courses.Include(c => c.Schedules.Where(cs => cs.TeacherId == teacherId).ToList());
            return _mapper.Map<List<CourseDto>>(courses);
        }
       
    }
}
