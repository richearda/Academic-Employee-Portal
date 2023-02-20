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
    public class TeacherCourseScheduleController : Controller
    {
        private ITeacherCourseScheduleService _teacherScheduleService;
        public TeacherCourseScheduleController(ITeacherCourseScheduleService teacherScheduleService)
        {
            _teacherScheduleService = teacherScheduleService;
        }
        [HttpPost(Routes.Add)]
        public async Task<IActionResult> AddTeacherSchedule([FromBody] Teacher teacher, [FromQuery] CourseSchedule courseSchedule)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                try
                {
                    TeacherCourseScheduleHandler teacherScheduleHandler = new TeacherCourseScheduleHandler(_teacherScheduleService);
                    ValidationResult error = teacherScheduleHandler.CanAddTeacherSchedule(teacher, courseSchedule);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _teacherScheduleService.AddTeacherSchedule(teacher, courseSchedule);
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
        public async Task<IActionResult> UpdateTeacherSchedule([FromBody] Teacher teacher, [FromQuery] CourseSchedule courseSchedule)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    TeacherCourseScheduleHandler TeacherScheduleHandler = new TeacherCourseScheduleHandler(_teacherScheduleService);
                    error = TeacherScheduleHandler.CanUpdateTeacherSchedule(teacher, courseSchedule);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _teacherScheduleService.UpdateTeacherSchedule(teacher, courseSchedule);
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
        public async Task<IActionResult> DeactivateTeacherSchedule(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    TeacherCourseScheduleHandler TeacherScheduleHandler = new TeacherCourseScheduleHandler(_teacherScheduleService);
                    error = TeacherScheduleHandler.CanCheckTeacherSchedule(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _teacherScheduleService.DeactivateTeacherSchedule(id);
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
        public async Task<IActionResult> ActivateTeacherSchedule(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    TeacherCourseScheduleHandler TeacherScheduleHandler = new TeacherCourseScheduleHandler(_teacherScheduleService);
                    error = TeacherScheduleHandler.CanCheckTeacherSchedule(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _teacherScheduleService.ActivateTeacherSchedule(id);
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
        public async Task<IActionResult> DeleteTeacherSchedule(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    TeacherCourseScheduleHandler TeacherScheduleHandler = new TeacherCourseScheduleHandler(_teacherScheduleService);
                    error = TeacherScheduleHandler.CanCheckTeacherSchedule(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _teacherScheduleService.DeleteTeacherSchedule(id);
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

        //url: api/TeacherSchedule/getlist
        [HttpGet(Routes.GetList)]
        public async Task<IEnumerable<TeacherCourseSchedule>> GetTeacherScheduleList()
        {
            return await _teacherScheduleService.GetTeacherSchedules().ToListAsync();
        }

        [HttpGet(Routes.Get)]
        public async Task<IActionResult> GetTeacherSchedule(int id)
        {
            TeacherCourseSchedule TeacherSchedule = null;
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    TeacherCourseScheduleHandler TeacherScheduleHandler = new TeacherCourseScheduleHandler(_teacherScheduleService);
                    error = TeacherScheduleHandler.CanCheckTeacherSchedule(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        TeacherSchedule = _teacherScheduleService.GetTeacherScheduleById(id);
                        return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, TeacherSchedule));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                }
            }
            return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, error.StatusCode));
        }

        [HttpGet(Routes.GetList + "/teacherSchedules")]
        public List<TeacherCourseSchedulesDto> GetCourseSchedulesByTeacherId(int teacherId)
        {
            return _teacherScheduleService.GetCourseSchedulesByTeacherId(teacherId);
        }
        [HttpGet(Routes.CourseNotInTeacherList)]
        public List<TeacherCourseSchedulesDto> GetCoursesNotInTeacherList([FromQuery] int[] courseSchedIds)
        {
            return _teacherScheduleService.GetCoursesNotInTeacherList(courseSchedIds);
        }

    }
}
