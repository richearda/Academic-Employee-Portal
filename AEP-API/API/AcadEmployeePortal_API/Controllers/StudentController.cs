using ISMS_API.DTOs;
using ISMS_API.Handlers;
using ISMS_API.Helpers;
using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class StudentController : Controller
    {
        private IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost(Routes.Add)]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                try
                {
                    StudentHandler studentHandler = new StudentHandler(_studentService);
                    ValidationResult error = studentHandler.CanAddStudent(student);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _studentService.AddStudent(student);
                        message = (status == 1) ? "success" : "failed";
                        return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, new { result = message }));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                }
            }
                return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200));            
        }

        [HttpPut(Routes.Edit)]
        public async Task<IActionResult> UpdateStudent([FromBody] Student student)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    StudentHandler studentHandler = new StudentHandler(_studentService);
                    error = studentHandler.CanUpdateStudent(student);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _studentService.UpdateStudent(student);
                        message = (status == 1) ? "success" : "failed";
                        return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, new { result = message }));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                }
            }
            return (error.StatusCode == 400) ? await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 400)) : await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 404));
        }

        [HttpPost(Routes.Deactivate)]
        public async Task<IActionResult> DeactivateStudent(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    StudentHandler StudentHandler = new StudentHandler(_studentService);
                    error = StudentHandler.CanCheckStudent(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _studentService.DeactivateStudent(id);
                        message = (status == 1) ? "success" : "failed";
                        return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, new { result = message }));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                }
            }
            return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, error.StatusCode));
        }

        [HttpPost(Routes.Activate)]
        public async Task<IActionResult> ActivateStudent(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    StudentHandler StudentHandler = new StudentHandler(_studentService);
                    error = StudentHandler.CanCheckStudent(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _studentService.ActivateStudent(id);
                        message = (status == 1) ? "success" : "failed";
                        return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, new { result = message }));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                }
            }
            return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, error.StatusCode));
        }

        [HttpDelete(Routes.Delete)]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    StudentHandler StudentHandler = new StudentHandler(_studentService);
                    error = StudentHandler.CanCheckStudent(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _studentService.DeleteStudent(id);
                        message = (status == 1) ? "success" : "failed";
                        return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, new { result = message }));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                }
            }
            return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, error.StatusCode));
        }

        //url: api/Student/getlist
        [HttpGet(Routes.GetList)]
        public List<StudentDto> GetStudentList()
        {
            return  _studentService.GetStudents();
        }

        [HttpGet(Routes.Get)]
        public async Task<IActionResult> GetStudent(int id)
        {
            Student Student = null;
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    StudentHandler StudentHandler = new StudentHandler(_studentService);
                    error = StudentHandler.CanCheckStudent(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        Student = _studentService.GetStudent(id);
                        return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, Student));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                }
            }
            return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, error.StatusCode));
        }
     
        [HttpGet(Routes.GetStudentInfo)]
        public StudentDto GetStudentDetails(int studentId)
        {
            return _studentService.GetStudentDetails(studentId);
        }
    }
}

