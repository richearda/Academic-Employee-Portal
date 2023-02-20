using AutoMapper;
using ISMS_API.Data;
using ISMS_API.DTOs;
using ISMS_API.Helpers;
using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services
{
    public class CourseScheduleService : ICourseScheduleService
    {
        private EmpPortalDbContext _dbContext;
        private IMapper _mapper;
        private IStudentService _studentService;
        private ITeacherService _teacherService;
        
        public CourseScheduleService(EmpPortalDbContext dbContext, IMapper mapper, IStudentService studentService,ITeacherService teacherService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _studentService = studentService;
            _teacherService = teacherService;
        }
        public int ActivateCourseSchedule(int scheduleId)
        {
            CourseSchedule activateSched = _dbContext.CourseSchedules.AsNoTracking().Where(s => s.CourseScheduleId == scheduleId).FirstOrDefault();
            activateSched.IsActive = true;
            _dbContext.Entry(activateSched).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int AddCourseSchedule(CourseSchedule schedule)
        {
            _dbContext.CourseSchedules.Add(schedule);
            return _dbContext.SaveChanges();
        }

        public int DeactivateCourseSchedule(int scheduleId)
        {
            CourseSchedule deactivateSched = _dbContext.CourseSchedules.AsNoTracking().Where(s => s.CourseScheduleId == scheduleId).FirstOrDefault();
            deactivateSched.IsActive = false;
            _dbContext.Entry(deactivateSched).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeleteCourseSchedule(int scheduleID)
        {
            CourseSchedule deleteSched = _dbContext.CourseSchedules.AsNoTracking().Where(s => s.CourseScheduleId == scheduleID).FirstOrDefault();
            _dbContext.Entry(deleteSched).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public IQueryable<CourseSchedule> GetCourseSchedules()
        {
            return _dbContext.CourseSchedules;
        }

        public CourseSchedule GetCourseScheduleById(int scheduleID)
        {
            return _dbContext.CourseSchedules.AsNoTracking().Where(s => s.CourseScheduleId == scheduleID).FirstOrDefault();
        }

        public bool IsCourseScheduleExist(CourseSchedule schedule)
        {
            CourseSchedule schedExist = _dbContext.CourseSchedules.Where(s => s.CourseScheduleId == schedule.CourseScheduleId).FirstOrDefault();           
            return (schedExist != null);
        }

        public int UpdateCourseSchedule(CourseSchedule schedule)
        {
            _dbContext.Entry(schedule).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public ICollection<TeacherCourseSchedulesDto> GetCourseScheduleByTeacher()
        {
            var courseSchedules = _dbContext.TeacherCourseSchedules.OrderBy(ts => ts.Teacher).Include(ts => ts.CourseSchedule).ThenInclude(cs => cs.Course)
                                  .Include(ts => ts.CourseSchedule).ThenInclude(cs => cs.Day).Include(cs => cs.CourseSchedule)
                                  .ThenInclude(cs => cs.MidDayTimeStart).Include(cs => cs.CourseSchedule)
                                  .ThenInclude(cs => cs.MidDayTimeEnd);
            //var courseSchedByTeacher = _dbContext.CourseSchedules.OrderBy(cs => cs.TeacherId).ToList();
            return _mapper.Map<ICollection<TeacherCourseSchedulesDto>>(courseSchedules);
        }

        //
        
       

        /// <summary>
        /// Get Subject Masterlist
        /// </summary>
        /// <param name="courseScheduleId">Course Schedule ID</param>
        /// <param name="teacherId">Teacher ID</param>
        /// <returns>Student List</returns>
        public List<StudentCourseSchedulesDto> GetTeacherCourseMasterList(int courseScheduleId)
        {
            var students = _dbContext.StudentCourseSchedules.AsNoTracking()
                           .Where(cs => cs.CourseScheduleId == courseScheduleId)
                           .Include(s => s.Student).ThenInclude(s => s.Program)
                           .Include(s => s.Student).ThenInclude(s => s.Major)
                           .Include(s => s.Student.Person).ThenInclude(p => p.Gender)
                           .Include(s => s.Student.Person).ThenInclude(p => p.CivilStatus)
                           .Include(s => s.Student.Person).ThenInclude(p => p.Citizenship);
                           
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
            return _mapper.Map<List<StudentCourseSchedulesDto>>(students);         
        }

        /// <summary>
        /// Get Student List that is not in masterlist
        /// </summary>
        /// <param name="courseScheduleId">Course Schedule ID</param>
        /// <param name="teacherId">Teacher ID</param>
        /// <returns>Student List</returns>
        public List<StudentCourseSchedulesDto> GetStudentsNotInMasterList(int[] studentId)
        {
        
            var students = _dbContext.StudentCourseSchedules.AsNoTracking()
                           .Where(cs => cs.StudentId == null || (!studentId.Contains((int)cs.StudentId)))
                           .Include(s => s.Student.Person).ThenInclude(p => p.Gender)
                           .Include(s => s.Student.Person).ThenInclude(p => p.CivilStatus)
                           .Include(s => s.Student.Person).ThenInclude(p => p.Citizenship)
                           .Include(s => s.Student).ThenInclude(s => s.Program)
                           .Include(s => s.Student).ThenInclude(s => s.Major).ToList()
                           .GroupBy(s => s.StudentId).Select(c => c.FirstOrDefault()).ToList();
            return _mapper.Map<List<StudentCourseSchedulesDto>>(students);
        }

        public List<StudentDto> GetUnenrolledStudents(int[] studentId)
        {
         

            var students = _dbContext.Students.AsNoTracking()
                           .Where(s => s.StudentID != 0 && (!studentId.Contains((int)s.StudentID)))
                           .Include(s => s.Person).ThenInclude(p => p.Gender)
                           .Include(s => s.Person).ThenInclude(p => p.CivilStatus)
                           .Include(s => s.Person).ThenInclude(p => p.Citizenship)
                           .Include(s => s.Program)
                           .Include(s => s.Major).ToList()
                           .GroupBy(s => s.StudentID).Select(c => c.FirstOrDefault()).ToList();
            return _mapper.Map<List<StudentDto>>(students);
        }

        /// <summary>
        /// Remove a student from a subject.
        /// </summary>
        /// <param name="studentId">Student ID</param>
        /// <param name="teacherId">Teacher ID</param>
        /// <param name="courseScheduleId">Course Schedule ID</param>
        /// <returns></returns>
        public int RemoveStudentFromCourseSchedule(int studentId, int courseScheduleId)
        {
            var student = _studentService.GetStudent(studentId);
            var course = GetCourseScheduleById(courseScheduleId);

            var studentSched = _dbContext.StudentCourseSchedules.Where(cs => cs.StudentId == student.StudentID && cs.CourseScheduleId == courseScheduleId).FirstOrDefault();
            _dbContext.Entry(studentSched).State = EntityState.Deleted;         
            return _dbContext.SaveChanges();
        }

        public TeacherCourseSchedule GetCourseScheduleByIdAndTeacherId(int coursescheduleId, int teacherId)
        {
            return _dbContext.TeacherCourseSchedules.Where(cs => cs.CourseScheduleId == coursescheduleId && cs.TeacherId == teacherId).FirstOrDefault();
        }
        /// <summary>
        /// Remove Teacher from cours
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="teacherId"></param>
        /// <param name="courseScheduleId"></param>
        /// <returns></returns>
        public int RemoveTeacherFromCourseSchedule(int teacherId, int courseScheduleId)
        {
           
            var removeTeacherSchedule = _dbContext.TeacherCourseSchedules.Where(t => t.TeacherId == teacherId && t.CourseScheduleId == courseScheduleId).FirstOrDefault();
            

            _dbContext.Entry(removeTeacherSchedule).State = EntityState.Deleted;                       
            return _dbContext.SaveChanges();
        }

        public int AddTeacherToCourseSchedule(int teacherId, int courseScheduleId)
        {
            var courseSchedule = GetCourseScheduleById(courseScheduleId);
            var teacher = _teacherService.GetTeacherById(teacherId);
            var teacherSchedule = new TeacherCourseSchedule
            {            
                TeacherId = teacher.TeacherId,
                CourseScheduleId = courseSchedule.CourseScheduleId,
                IsActive = true

            };
            _dbContext.TeacherCourseSchedules.Add(teacherSchedule);
            return _dbContext.SaveChanges();
            
        }

        public List<CourseSchedulesDto> GetCourseScheduleByDepartment(int[] departmentId)
        {
            var courses = _dbContext.CourseSchedules.Include(cs => cs.Course).Where(cs => cs.Course.DepartmentID != 0 && (departmentId.Contains((int)cs.Course.DepartmentID)))
                          .Include(cs => cs.Day)
                          .Include(cs => cs.MidDayTimeStart)
                          .Include(cs => cs.MidDayTimeEnd).ToList();
                          
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
            return _mapper.Map<List<CourseSchedulesDto>>(courses);
        }
        


    }
}
