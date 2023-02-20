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
    public class TeacherService : ITeacherService
    {
        private EmpPortalDbContext _dbContext;
        private ICourseService _courseService;
        private IMapper _mapper;
        public TeacherService(EmpPortalDbContext dbContext, IMapper mapper, ICourseService courseService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _courseService = courseService;
        }
        public int ActivateTeacher(int teacherId)
        {
            Teacher activateTeacher = _dbContext.Teachers.AsNoTracking().Where(t => t.TeacherId == teacherId).FirstOrDefault();
            activateTeacher.IsActive = true;
            _dbContext.Entry(activateTeacher).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int AddTeacher(Teacher teacher)
        {
            _dbContext.Teachers.Add(teacher);
            return _dbContext.SaveChanges();
        }

        public int DeactivateTeacher(int teacherId)
        {
            Teacher deactivateTeacher = _dbContext.Teachers.AsNoTracking().Where(t => t.TeacherId == teacherId).FirstOrDefault();
            deactivateTeacher.IsActive = false;
            _dbContext.Entry(deactivateTeacher).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeleteTeacher(int teacherId)
        {
            _dbContext.Teachers.Include(c => c.College).Where(c => c.TeacherId == teacherId);
            Teacher deleteTeacher = _dbContext.Teachers.AsNoTracking().Where(t => t.TeacherId == teacherId).FirstOrDefault();
            _dbContext.Entry(deleteTeacher).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public ICollection<TeacherDto> GetTeachers()
        {
           var teachers = _dbContext.Teachers.AsNoTracking().Include(t => t.Person).ThenInclude(p => p.Gender)
                .Include(t => t.Person).ThenInclude(p => p.CivilStatus).Include(t => t.Person).ThenInclude(p => p.Citizenship)
                .Include(t => t.College);
            return _mapper.Map<ICollection<TeacherDto>>(teachers);
        }

        public ICollection<TeacherDto> GetTeachersByCollege(string collegeName)
        {
            var teachers = GetTeachers().Where(t => t.College.CollegeName == collegeName) ;
            return _mapper.Map<ICollection<TeacherDto>>(teachers);
        }

        public Teacher GetTeacherById(int teacherId)
        {
            return _dbContext.Teachers.AsNoTracking().Where(t => t.TeacherId == teacherId).FirstOrDefault();          
        }

        public bool IsTeacherExist(Teacher teacher)
        {
            Teacher teacherExist = _dbContext.Teachers.AsNoTracking().Where(t => t.TeacherId == teacher.TeacherId).FirstOrDefault();
            return (teacherExist != null);
        }

        public int UpdateTeacher(Teacher teacher)
        {
            _dbContext.Entry(teacher).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }
        public TeacherDto GetTeacherDetails(int teacherId)
        {
            var teacherDetails = _dbContext.Teachers.AsNoTracking().Where(t => t.TeacherId == teacherId)                                 
                                 .Include(t => t.College).Include(t => t.Person).ThenInclude(p => p.Gender)                                 
                                 .Include(t => t.Person).ThenInclude(p => p.CivilStatus)
                                 .Include(t => t.Person).ThenInclude(p => p.Citizenship)
                                 .Include(t => t.Person).ThenInclude(p => p.Address)
                                 .Include(t => t.Person).ThenInclude(p => p.Address).ThenInclude(a => a.Barangay)
                                 .Include(t => t.Person).ThenInclude(p => p.Address).ThenInclude(a => a.CityMunicipality)
                                 .Include(t => t.Person).ThenInclude(p => p.Address).ThenInclude(a => a.Province)
                                 //.Include(t => t.Person).ThenInclude(p => p.Address).ThenInclude(a => a.AddressType)
                                 .Include(t => t.Person).ThenInclude(p => p.Employee)
                                 .Include(t => t.Person).ThenInclude(p => p.Employee).ThenInclude(e => e.EmployeeClassification)
                                 .Include(t => t.Person).ThenInclude(p => p.Employee).ThenInclude(e => e.DesignationStatus).FirstOrDefault();
                                 _mapper.ConfigurationProvider.AssertConfigurationIsValid();
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
            return _mapper.Map<TeacherDto>(teacherDetails);
        }
        public TeacherDto GetTeacherByPersonId(int personId)
        {
            var teacherDetails = _dbContext.Teachers.AsNoTracking().Where(t => t.PersonId == personId)
                                 .Include(t => t.Person).FirstOrDefault();
                                 //.ThenInclude(p => p.Gender)
                                 //.Include(t => t.Person).ThenInclude(p => p.CivilStatus)
                                 //.Include(t => t.Person).ThenInclude(p => p.Citizenship)
                                 //.Include(t => t.College)
                                 ////.Include(t => t.Person).ThenInclude(p => p.Addresses)
                                 ////.Include(t => t.Person).ThenInclude(p => p.Addresses).ThenInclude(a => a.AddressType)
                                 //.Include(t => t.Person).ThenInclude(p => p.Employee)
                                 //.Include(t => t.Person).ThenInclude(p => p.Employee).ThenInclude(e => e.EmployeeClassification)
                                 //.Include(t => t.Person).ThenInclude(p => p.Employee).ThenInclude(e => e.DesignationStatus).FirstOrDefault();
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
            return _mapper.Map<TeacherDto>(teacherDetails);
        }

    }
}
