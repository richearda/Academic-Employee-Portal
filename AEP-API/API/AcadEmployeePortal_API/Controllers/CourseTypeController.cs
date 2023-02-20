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
    public class CourseTypeController : Controller
    {
        private ICourseTypeService _courseTypeService;
        public CourseTypeController(ICourseTypeService courseTypeService)
        {
            _courseTypeService = courseTypeService;
        }
        [HttpPost(Routes.Add)]
        public async Task<IActionResult> AddCourseType([FromBody] CourseType courseType)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                try
                {
                    CourseTypeHandler courseTypeHandler = new CourseTypeHandler(_courseTypeService);
                    ValidationResult error = courseTypeHandler.CanAddCourseType(courseType);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _courseTypeService.AddCourseType(courseType);
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
        public async Task<IActionResult> UpdateCourseType([FromBody] CourseType courseType)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    CourseTypeHandler courseTypeHandler = new CourseTypeHandler(_courseTypeService);
                    error = courseTypeHandler.CanUpdateCourseType(courseType);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _courseTypeService.UpdateCourseType(courseType);
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
        public async Task<IActionResult> DeactivateCourseType(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    CourseTypeHandler CourseTypeHandler = new CourseTypeHandler(_courseTypeService);
                    error = CourseTypeHandler.CanCheckCourseType(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _courseTypeService.DeactivateCourseType(id);
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
        public async Task<IActionResult> ActivateCourseType(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    CourseTypeHandler CourseTypeHandler = new CourseTypeHandler(_courseTypeService);
                    error = CourseTypeHandler.CanCheckCourseType(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _courseTypeService.ActivateCourseType(id);
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
        public async Task<IActionResult> DeleteCourseType(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    CourseTypeHandler CourseTypeHandler = new CourseTypeHandler(_courseTypeService);
                    error = CourseTypeHandler.CanCheckCourseType(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _courseTypeService.DeleteCourseType(id);
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

        //url: api/CourseType/getlist
        [HttpGet(Routes.GetList)]
        public async Task<IEnumerable<CourseType>> GetCourseTypeList()
        {
            return await _courseTypeService.GetCourseTypes().ToListAsync();
        }

        [HttpGet(Routes.Get)]
        public async Task<IActionResult> GetCourseType(int id)
        {
            CourseType CourseType = null;
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    CourseTypeHandler CourseTypeHandler = new CourseTypeHandler(_courseTypeService);
                    error = CourseTypeHandler.CanCheckCourseType(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        CourseType = _courseTypeService.GetCourseType(id);
                        return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, CourseType));
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
