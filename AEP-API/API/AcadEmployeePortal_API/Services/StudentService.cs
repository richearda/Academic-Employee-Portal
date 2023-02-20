using AutoMapper;
using AutoMapper.QueryableExtensions;
using ISMS_API.Data;
using ISMS_API.DTOs;
using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ISMS_API.Services
{
    public class StudentService : IStudentService
    {
        private EmpPortalDbContext _dbContext;
        private IMapper _mapper;
        public StudentService(EmpPortalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int AddStudent(Student student)
        {
            _dbContext.Students.Add(student);
            return _dbContext.SaveChanges();      
        }

        public int UpdateStudent(Student student)
        {
            _dbContext.Entry(student).State = EntityState.Modified;
            return _dbContext.SaveChanges();  
        }

        public int DeleteStudent(int ID)
        {
            Student toDelete = _dbContext.Students.AsNoTracking().Where(s => s.StudentID == ID).FirstOrDefault();
            _dbContext.Entry(toDelete).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }


        public Student GetStudent(int ID)
        {
            return _dbContext.Students.AsNoTracking().Where(s => s.StudentID == ID).FirstOrDefault();      
        }

        public List<StudentDto> GetStudents()
        {
            var students = _dbContext.Students.Include(s => s.Person).ThenInclude(p => p.Gender)
                    .Include(s => s.Person).ThenInclude(p => p.CivilStatus)
                    .Include(s => s.Person).ThenInclude(p => p.Citizenship)
                    .Include(s => s.Program).Include(s => s.Major).ToList();
            return _mapper.Map<List<StudentDto>>(students);
            //return  _dbContext.Students.Include(s => s.Person).ProjectTo<StudentDto>(_mapper.ConfigurationProvider).ToList();
        }

        public int ActivateStudent(int ID)
        {
            Student toActivate = _dbContext.Students.AsNoTracking().Where(s => s.StudentID == ID).FirstOrDefault();
            toActivate.IsActive = true;
            _dbContext.Entry(toActivate).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeactivateStudent(int ID)
        {
            Student toDeactivate = _dbContext.Students.AsNoTracking().Where(s => s.StudentID == ID).FirstOrDefault();
            toDeactivate.IsActive = false;
            _dbContext.Entry(toDeactivate).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public bool IsStudentExist(Student student)
        {
            Student checkStudent = _dbContext.Students.Where(s => s.StudentNo == student.StudentNo).FirstOrDefault();
            return (checkStudent != null);
        }

        public StudentCourseSchedulesDto GetStudentPersonalInfoById(int studentID)
        {
            var studentInfo = _dbContext.StudentCourseSchedules.AsNoTracking().Where(s => s.StudentId == studentID)
                           .Include(s => s.Student).ThenInclude(s => s.Program)
                           .Include(s => s.Student).ThenInclude(s => s.Major)
                           .Include(s => s.Student.Person).ThenInclude(p => p.Gender)
                           .Include(s => s.Student.Person).ThenInclude(p => p.CivilStatus)
                           .Include(s => s.Student.Person).ThenInclude(p => p.Citizenship)
                           .Include(s => s.Student.Person).ThenInclude(p => p.Address);
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
            return _mapper.Map<StudentCourseSchedulesDto>(studentInfo);
        }

        public StudentDto GetStudentDetails(int studentId)
        {
            var students = _dbContext.Students.Where(s => s.StudentID == studentId)
                        .Include(s => s.Person).ThenInclude(p => p.Gender)
                        .Include(s => s.Person).ThenInclude(p => p.CivilStatus)
                        .Include(s => s.Person).ThenInclude(p => p.Citizenship)
                        .Include(s => s.Person).ThenInclude(p => p.Address)
                        .Include(s => s.Person).ThenInclude(p => p.Address).ThenInclude(a => a.Barangay)
                        .Include(s => s.Person).ThenInclude(p => p.Address).ThenInclude(a => a.CityMunicipality)
                        .Include(s => s.Person).ThenInclude(p => p.Address).ThenInclude(a => a.Province)
                        .Include(s => s.Program).Include(s => s.Major).FirstOrDefault();
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
            return _mapper.Map<StudentDto>(students);
        }
    }
}
