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
    public class CourseScheduleController : Controller
    {
        private ICourseScheduleService _scheduleService;
        public CourseScheduleController(ICourseScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpPost(Routes.Add)]
        public async Task<IActionResult> AddSchedule([FromBody] CourseSchedule schedule)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                try
                {
                    ScheduleHandler scheduleHandler = new ScheduleHandler(_scheduleService);
                    ValidationResult error = scheduleHandler.CanAddSchedule(schedule);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _scheduleService.AddCourseSchedule(schedule);
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
        public async Task<IActionResult> UpdateSchedule([FromBody] CourseSchedule schedule)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    ScheduleHandler scheduleHandler = new ScheduleHandler(_scheduleService);
                    error = scheduleHandler.CanUpdateSchedule(schedule);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _scheduleService.UpdateCourseSchedule(schedule);
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
        public async Task<IActionResult> DeactivateSchedule(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    ScheduleHandler scheduleHandler = new ScheduleHandler(_scheduleService);
                    error = scheduleHandler.CanCheckSchedule(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _scheduleService.DeactivateCourseSchedule(id);
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
        public async Task<IActionResult> ActivateSchedule(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    ScheduleHandler scheduleHandler = new ScheduleHandler(_scheduleService);
                    error = scheduleHandler.CanCheckSchedule(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _scheduleService.ActivateCourseSchedule(id);
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
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    ScheduleHandler scheduleHandler = new ScheduleHandler(_scheduleService);
                    error = scheduleHandler.CanCheckSchedule(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _scheduleService.DeleteCourseSchedule(id);
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

        //url: api/Schedule/getlist
        [HttpGet(Routes.GetList)]
        public async Task<IEnumerable<CourseSchedule>> GetScheduleList()
        {
            return await _scheduleService.GetCourseSchedules().ToListAsync();
        }

        [HttpGet(Routes.Get)]
        public async Task<IActionResult> GetSchedule(int id)
        {
            CourseSchedule schedule = null;
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    ScheduleHandler scheduleHandler = new ScheduleHandler(_scheduleService);
                    error = scheduleHandler.CanCheckSchedule(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        schedule = _scheduleService.GetCourseScheduleById(id);
                        return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, schedule));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                }
            }
            return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, error.StatusCode));
        }
        [HttpGet(Routes.GetList + "/orderByTeacher")]
        public ICollection<TeacherCourseSchedulesDto> GetCourseScheduleByTeacher()
        {
            return _scheduleService.GetCourseScheduleByTeacher();
        }



        [HttpGet(Routes.GetList + "/scheduleMasterList")]
        public List<StudentCourseSchedulesDto> GetTeacherCourseMasterList(int courseScheduleId)
        {
            return _scheduleService.GetTeacherCourseMasterList(courseScheduleId);
        }   

        [HttpDelete(Routes.RemoveStudent)]
        public int RemoveStudentFromCourse(int studentId, int courseScheduleId)
        {
            return _scheduleService.RemoveStudentFromCourseSchedule(studentId, courseScheduleId);
        }

        [HttpPut(Routes.RemoveTeacherCourseSchedule)]
        public int RemoveTeacherFromCourseSchedule(int teacherId, int courseScheduleId)
        {
            return _scheduleService.RemoveTeacherFromCourseSchedule(teacherId, courseScheduleId);
        }
        [HttpGet(Routes.Get + "/course")]
        public TeacherCourseSchedule GetCourseScheduleByIdAndTeacherId(int coursescheduleId, int teacherId)
        {
            return _scheduleService.GetCourseScheduleByIdAndTeacherId(coursescheduleId, teacherId);
        }
        [HttpGet(Routes.GetList + "/DepartmentCourses")]
        public List<CourseSchedulesDto> GetCourseScheduleByDepartment([FromQuery] int[] departmentId)
        {
            return _scheduleService.GetCourseScheduleByDepartment(departmentId);
        }
        [HttpPost(Routes.AddTeacherCourseSchedule)]
        public int AddTeacherToCourseSchedule(int teacherId, int courseScheduleId)
        {
           return  _scheduleService.AddTeacherToCourseSchedule(teacherId, courseScheduleId);
        }

        [HttpGet(Routes.GetList + "/studentsnotinlist")]
        public List<StudentDto> GetUnenrolledStudents([FromQuery] int[] studentId)
        {
           return _scheduleService.GetUnenrolledStudents(studentId);
        }



    }
}
