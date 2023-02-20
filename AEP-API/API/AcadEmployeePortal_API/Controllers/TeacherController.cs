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
    public class TeacherController : Controller
    {
        private ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        [HttpPost(Routes.Add)]
        public async Task<IActionResult> AddTeacher([FromBody] Teacher teacher)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                try
                {
                    TeacherHandler teacherHandler = new TeacherHandler(_teacherService);
                    ValidationResult error = teacherHandler.CanAddTeacher(teacher);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _teacherService.AddTeacher(teacher);
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
        public async Task<IActionResult> UpdateTeacher([FromBody] Teacher Teacher)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    TeacherHandler TeacherHandler = new TeacherHandler(_teacherService);
                    error = TeacherHandler.CanUpdateTeacher(Teacher);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _teacherService.UpdateTeacher(Teacher);
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
        public async Task<IActionResult> DeactivateTeacher(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    TeacherHandler TeacherHandler = new TeacherHandler(_teacherService);
                    error = TeacherHandler.CanCheckTeacher(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _teacherService.DeactivateTeacher(id);
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
        public async Task<IActionResult> ActivateTeacher(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    TeacherHandler TeacherHandler = new TeacherHandler(_teacherService);
                    error = TeacherHandler.CanCheckTeacher(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _teacherService.ActivateTeacher(id);
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
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    TeacherHandler TeacherHandler = new TeacherHandler(_teacherService);
                    error = TeacherHandler.CanCheckTeacher(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _teacherService.DeleteTeacher(id);
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

        //url: api/Teacher/getlist
        [HttpGet(Routes.GetList)]
        public ICollection<TeacherDto> GetTeacherList()
        {
            return _teacherService.GetTeachers();
        }


        [HttpGet(Routes.GetList +"/teacherByCollege")]
        public IEnumerable<TeacherDto> GetTeachersByCollege(string collegeName)
        {
           return _teacherService.GetTeachersByCollege(collegeName);
        }
        [HttpGet(Routes.GetDetails)]
        public TeacherDto GetTeacherDetails(int teacherId)
        {
            return _teacherService.GetTeacherDetails(teacherId);
        }

        [HttpGet(Routes.GetTeacherByPersonId)]
        public TeacherDto GetTeacherByPersonId(int personId)
        {
            return _teacherService.GetTeacherByPersonId(personId);
        }
        [HttpGet(Routes.Get)]
        public Teacher GetTeacherById(int teacherId)
        {
            return _teacherService.GetTeacherById(teacherId);
        }
    }
}
