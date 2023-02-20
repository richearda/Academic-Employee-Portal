using ISMS_API.DTOs;
using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface IStudentService
    {
       
        int AddStudent(Student student);
        int UpdateStudent(Student student);
        int DeleteStudent(int studentID);
        List<StudentDto> GetStudents();
        Student GetStudent(int studentID);
        int ActivateStudent(int ID);
        int DeactivateStudent(int ID);
        bool IsStudentExist(Student student);
        StudentCourseSchedulesDto GetStudentPersonalInfoById(int studentID);

        StudentDto GetStudentDetails(int studentId);


    }
}
