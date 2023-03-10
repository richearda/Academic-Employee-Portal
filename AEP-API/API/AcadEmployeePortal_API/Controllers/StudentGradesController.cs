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
    public class StudentGradesController : Controller
    {
        private IStudentGradesService _studentGradesService;
        public StudentGradesController(IStudentGradesService studentGradesService)
        {
            _studentGradesService = studentGradesService;
        }
        [HttpPost(Routes.Add)]
        public async Task<IActionResult> AddStudentGrades([FromBody] StudentGrades studentGrades)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                try
                {
                    StudentGradesHandler studentGradesHandler = new StudentGradesHandler(_studentGradesService);
                    ValidationResult error = studentGradesHandler.CanAddStudentGrades(studentGrades);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _studentGradesService.AddStudentGrades(studentGrades);
                        message = (status == 1) ? "success" : "failed";
                        return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, new { result = message }));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                }
            }
            return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 400));
        }
        [HttpPut(Routes.Edit)]
        public async Task<IActionResult> UpdateStudentGrades([FromBody] StudentGrades StudentGrades)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    StudentGradesHandler studentGradesHandler = new StudentGradesHandler(_studentGradesService);
                    error = studentGradesHandler.CanUpdateStudentGrades(StudentGrades);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _studentGradesService.UpdateStudentGrades(StudentGrades);
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

        [HttpDelete(Routes.Delete)]
        public async Task<IActionResult> DeleteStudentGrades(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    StudentGradesHandler studentGradesHandler = new StudentGradesHandler(_studentGradesService);
                    error = studentGradesHandler.CanCheckStudentGrades(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _studentGradesService.DeleteStudentGrades(id);
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

        //url: api/StudentGrades/getlist
        [HttpGet(Routes.GetList)]
        public async Task<IEnumerable<StudentGrades>> GetStudentGradesList()
        {
            return await _studentGradesService.GetStudentGrades().ToListAsync();
        }

        [HttpGet(Routes.Get)]
        public async Task<IActionResult> GetStudentGrades(int id)
        {
            StudentGrades studentGrades = null;
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    StudentGradesHandler StudentGradesHandler = new StudentGradesHandler(_studentGradesService);
                    error = StudentGradesHandler.CanCheckStudentGrades(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        studentGrades = _studentGradesService.GetStudentGradesById(id);
                        return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, studentGrades));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                }
            }
            return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, error.StatusCode));
        }
    }
}
