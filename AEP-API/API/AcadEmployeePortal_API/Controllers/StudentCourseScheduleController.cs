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
    public class StudentCourseScheduleController : Controller
    {
        private IStudentCourseScheduleService _studentScheduleService;
        public StudentCourseScheduleController(IStudentCourseScheduleService studentScheduleService)
        {
            _studentScheduleService = studentScheduleService;
        }
        [HttpPost(Routes.Add)]
        public async Task<IActionResult> AddStudentSchedule([FromBody] StudentCourseSchedule studentSchedule)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                try
                {
                    StudentScheduleHandler studentScheduleHandler = new StudentScheduleHandler(_studentScheduleService);
                    ValidationResult error = studentScheduleHandler.CanAddStudentSchedule(studentSchedule);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _studentScheduleService.AddStudentSchedule(studentSchedule);
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
        public async Task<IActionResult> UpdateStudentSchedule([FromBody] StudentCourseSchedule studentSchedule)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    StudentScheduleHandler StudentScheduleHandler = new StudentScheduleHandler(_studentScheduleService);
                    error = StudentScheduleHandler.CanUpdateStudentSchedule(studentSchedule);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _studentScheduleService.UpdateStudentSchedule(studentSchedule);
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
        public async Task<IActionResult> DeactivateStudentSchedule(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    StudentScheduleHandler StudentScheduleHandler = new StudentScheduleHandler(_studentScheduleService);
                    error = StudentScheduleHandler.CanCheckStudentSchedule(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _studentScheduleService.DeactivateStudentSchedule(id);
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
        public async Task<IActionResult> ActivateStudentSchedule(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    StudentScheduleHandler StudentScheduleHandler = new StudentScheduleHandler(_studentScheduleService);
                    error = StudentScheduleHandler.CanCheckStudentSchedule(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _studentScheduleService.ActivateStudentSchedule(id);
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
        public async Task<IActionResult> DeleteStudentSchedule(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    StudentScheduleHandler StudentScheduleHandler = new StudentScheduleHandler(_studentScheduleService);
                    error = StudentScheduleHandler.CanCheckStudentSchedule(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _studentScheduleService.DeleteStudentSchedule(id);
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

        //url: api/StudentSchedule/getlist
        [HttpGet(Routes.GetList)]
        public async Task<IEnumerable<StudentCourseSchedule>> GetStudentScheduleList()
        {
            return await _studentScheduleService.GetStudentSchedules().ToListAsync();
        }

        [HttpGet(Routes.Get)]
        public async Task<IActionResult> GetStudentSchedule(int id)
        {
            StudentCourseSchedule studentSchedule = null;
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    StudentScheduleHandler StudentScheduleHandler = new StudentScheduleHandler(_studentScheduleService);
                    error = StudentScheduleHandler.CanCheckStudentSchedule(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        studentSchedule = _studentScheduleService.GetStudentSchedule(id);
                        return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, studentSchedule));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                }
            }
            return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, error.StatusCode));
        }
        [HttpPost(Routes.Add+"/studentschedule")]
        public int AddStudentSchedule(int studentId, int courseScheduleId)
        {
           return _studentScheduleService.AddStudentSchedule(studentId, courseScheduleId);
        }

        [HttpGet(Routes.Get + "/studentcourseschedule")]
        public StudentCourseSchedule GetStudentCourseSchedule(int studentId)
        {
            return _studentScheduleService.GetStudentCourseSchedule(studentId);
        }
    }
}
