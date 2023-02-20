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
    public class TeacherCourseScheduleService : ITeacherCourseScheduleService
    {
        private EmpPortalDbContext _dbContext;
        private IMapper _mapper;
        private ITeacherService _teacherService;
        private ICourseScheduleService _courseScheduleService;
        public TeacherCourseScheduleService(EmpPortalDbContext dbContext, IMapper mapper, ITeacherService teacherService, ICourseScheduleService courseScheduleService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _teacherService = teacherService;
            _courseScheduleService = courseScheduleService;
        }
        public int ActivateTeacherSchedule(int teacherScheduleId)
        {
            TeacherCourseSchedule activateTeacherSched = _dbContext.TeacherCourseSchedules.AsNoTracking().Where(t => t.TeacherCourseScheduleId == teacherScheduleId).FirstOrDefault();
            activateTeacherSched.IsActive = true;
            _dbContext.Entry(activateTeacherSched).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int AddTeacherSchedule(Teacher teacher, CourseSchedule courseSchedule)
        {
            var existingTeacher = _dbContext.Teachers.Include(t => t.TeacherCourseSchedules).Where(t => t.TeacherId == teacher.TeacherId).FirstOrDefault();
            var existingCourseSchedule = _dbContext.CourseSchedules.Include(cs => cs.TeacherCourseSchedules).Where(cs => cs.CourseScheduleId == courseSchedule.CourseScheduleId).FirstOrDefault();
            existingTeacher.TeacherCourseSchedules.Add(new TeacherCourseSchedule
            {
                Teacher = existingTeacher,
                CourseSchedule = existingCourseSchedule
            });
            return _dbContext.SaveChanges();
        }

        public int DeactivateTeacherSchedule(int teacherScheduleId)
        {
            TeacherCourseSchedule deactivateTeacherSched = _dbContext.TeacherCourseSchedules.AsNoTracking().Where(t => t.TeacherCourseScheduleId == teacherScheduleId).FirstOrDefault();
            deactivateTeacherSched.IsActive = false;
            _dbContext.Entry(deactivateTeacherSched).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeleteTeacherSchedule(int teacherScheduleId)
        {
            TeacherCourseSchedule deleteTeacherSched = _dbContext.TeacherCourseSchedules.AsNoTracking().Where(t => t.TeacherCourseScheduleId == teacherScheduleId).FirstOrDefault();
            _dbContext.Entry(deleteTeacherSched).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public TeacherCourseSchedule GetTeacherScheduleById(int teacherScheduleId)
        {
            return _dbContext.TeacherCourseSchedules.AsNoTracking().Where(t => t.TeacherCourseScheduleId == teacherScheduleId).FirstOrDefault();
        }

        public IQueryable<TeacherCourseSchedule> GetTeacherSchedules()
        {
            //return _dbContext.Teachers.Include(t => t.TeacherCourseSchedules).ThenInclude(ts => ts.CourseSchedule).ToList();
            return _dbContext.TeacherCourseSchedules.Include(ts => ts.CourseSchedule);
               //.ThenInclude(t => t.Teacher).Where(t => t.Teacher.TeacherId == t.CourseSchedule.TeacherId);
        }

        public bool IsTeacherScheduleExist(Teacher teacher, CourseSchedule courseSchedule)
        {         
            var isTeacherExist = _teacherService.IsTeacherExist(teacher);
            var isCourseScheduleExist = _courseScheduleService.IsCourseScheduleExist(courseSchedule);
            return (isTeacherExist && isCourseScheduleExist);
        }

        //Needs to be change later.
        public int UpdateTeacherSchedule(Teacher teacher, CourseSchedule courseSchedule)
        {
            var teacherSchedule = _dbContext.Teachers.Where(t => t.TeacherId == teacher.TeacherId);
            _dbContext.Entry(teacherSchedule).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public List<TeacherCourseSchedulesDto> GetCourseSchedulesByTeacherId(int teacherId)
        {
            var courseSchedules = _dbContext.TeacherCourseSchedules.AsNoTracking().Where(cs => cs.TeacherId == teacherId)
                                      .Include(cs => cs.CourseSchedule).ThenInclude(cs => cs.Course)
                                      .Include(cs => cs.CourseSchedule).ThenInclude(cs => cs.Course).ThenInclude(c => c.CourseType)
                                      .Include(cs => cs.CourseSchedule).ThenInclude(cs => cs.MidDayTimeStart)
                                      .Include(cs => cs.CourseSchedule).ThenInclude(cs => cs.MidDayTimeEnd)
                                      .Include(cs => cs.CourseSchedule).ThenInclude(cs => cs.Day);
            return _mapper.Map<List<TeacherCourseSchedulesDto>>(courseSchedules);
        }

        public List<TeacherCourseSchedulesDto> GetCoursesNotInTeacherList(int[] courseSchedIds)
        {
            var courses = _dbContext.TeacherCourseSchedules.AsNoTracking()
                           .Include(t => t.CourseSchedule).Where(t => t.CourseScheduleId != null && (!courseSchedIds.Contains((int)t.CourseScheduleId)))
                           .Include(cs => cs.CourseSchedule).ThenInclude(cs => cs.Course)
                           .Include(cs => cs.CourseSchedule).ThenInclude(cs => cs.Course).ThenInclude(c => c.CourseType)
                           .Include(cs => cs.CourseSchedule).ThenInclude(cs => cs.MidDayTimeStart)
                           .Include(cs => cs.CourseSchedule).ThenInclude(cs => cs.MidDayTimeEnd)
                           .Include(cs => cs.CourseSchedule).ThenInclude(cs => cs.Day);

            return _mapper.Map<List<TeacherCourseSchedulesDto>>(courses);
        }

    }
}
