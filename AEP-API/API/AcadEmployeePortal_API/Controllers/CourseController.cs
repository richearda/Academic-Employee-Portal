using ISMS_API.DTOs;
using ISMS_API.Handlers;
using ISMS_API.Helpers;
using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISMS_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CourseController : Controller
    {

        private ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpPost(Routes.Add)]
        public async Task<IActionResult> AddCourse([FromBody] Course Course)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                try
                {
                    CourseHandler CourseHandler = new CourseHandler(_courseService);
                    ValidationResult error = CourseHandler.CanAddCourse(Course);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _courseService.AddCourse(Course);
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
        public async Task<IActionResult> UpdateCourse([FromBody] Course Course)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    CourseHandler CourseHandler = new CourseHandler(_courseService);
                    error = CourseHandler.CanUpdateCourse(Course);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _courseService.UpdateCourse(Course);
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
        public async Task<IActionResult> DeactivateCourse(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    CourseHandler CourseHandler = new CourseHandler(_courseService);
                    error = CourseHandler.CanCheckCourse(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _courseService.DeactivateCourse(id);
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
        public async Task<IActionResult> ActivateCourse(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    CourseHandler CourseHandler = new CourseHandler(_courseService);
                    error = CourseHandler.CanCheckCourse(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _courseService.ActivateCourse(id);
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
        public async Task<IActionResult> DeleteCourse(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    CourseHandler CourseHandler = new CourseHandler(_courseService);
                    error = CourseHandler.CanCheckCourse(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _courseService.DeleteCourse(id);
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

        //url: api/Course/getlist
        [HttpGet(Routes.GetList)]
        public async Task<IEnumerable<CourseDto>> GetCourseList()
        {
            return await _courseService.GetCourses();
        }

        [HttpGet(Routes.Get)]
        public async Task<IActionResult> GetCourse(int id)
        {
            Course Course = null;
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    CourseHandler CourseHandler = new CourseHandler(_courseService);
                    error = CourseHandler.CanCheckCourse(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        Course = _courseService.GetCourse(id);
                        return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, Course));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                }
            }
            return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, error.StatusCode));
        }
        [HttpGet(Routes.GetList+"/teachercourses")]
        public List<CourseDto> GetCourseByTeacherId(int teacherId)
        {
            return  _courseService.GetCourseByTeacherId(teacherId);
        }
    }
}
