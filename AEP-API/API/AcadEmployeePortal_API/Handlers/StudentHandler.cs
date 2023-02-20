using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Handlers
{
    public class StudentHandler
    {
        private IStudentService _studentService;

        public StudentHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }
        //Validate if the student already exist or the required field contains value.
        public ValidationResult CanAddStudent(Student student)
        {
            ValidationResult result = null;
            if (student.StudentNo != null && student.StudentNo != "")
            {
                if ((student.StudentNo != null || student.StudentNo!= ""))
                {
                    if (_studentService.IsStudentExist(student))
                        result = new ValidationResult("StudentNo", "Already existing", 400);
                }
                else
                    result = new ValidationResult("StudentNo", "Required", 400);
            }
            else
                result = new ValidationResult("StudentNo", "Required", 400);
            return result;
        }

        public ValidationResult CanUpdateStudent(Student student)
        {
            ValidationResult result = null;
            Student checkStudent = _studentService.GetStudent(student.StudentID);

            if (checkStudent != null)
            {
                if (student.StudentNo == null || student.StudentNo == "")
                    result = new ValidationResult("StudentNo", "Required", 400);
                else if ((student.PersonId == 0 || student.PersonId < 0))
                    result = new ValidationResult("PersonID", "Required", 400);
                else if ((student.ProgramId == 0 || student.ProgramId < 0))
                    result = new ValidationResult("ProgramID", "Required", 400);
                else if ((student.MajorId == 0 || student.MajorId < 0))
                    result = new ValidationResult("MajorID", "Required", 400);               
            }
            else
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }

        //Validate if the student exist.
        public ValidationResult CanCheckStudent(int ID)
        {
            ValidationResult result = null;
            Student student = _studentService.GetStudent(ID);
            if (student == null)
                result = new ValidationResult("Error", "Student does not exist.", 404);
            return result;
        }
        

    }
}
