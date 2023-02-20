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
    public class SemesterController : Controller
    {
        private ISemesterService _semesterService;
        public SemesterController(ISemesterService semesterService)
        {
            _semesterService = semesterService;
        }

        [HttpPost(Routes.Add)]
        public async Task<IActionResult> AddSemester([FromBody] Semester semester)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                try
                {
                    SemesterHandler semesterHandler = new SemesterHandler(_semesterService);
                    ValidationResult error = semesterHandler.CanAddSemester(semester);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _semesterService.AddSemester(semester);
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
        public async Task<IActionResult> UpdateSemester([FromBody] Semester semester)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    SemesterHandler semesterHandler = new SemesterHandler(_semesterService);
                    error = semesterHandler.CanUpdateSemester(semester);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _semesterService.UpdateSemester(semester);
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
        public async Task<IActionResult> DeactivateSemester(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    SemesterHandler semesterHandler = new SemesterHandler(_semesterService);
                    error = semesterHandler.CanCheckSemester(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _semesterService.DeactivateSemester(id);
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
        public async Task<IActionResult> ActivateSemester(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    SemesterHandler semesterHandler = new SemesterHandler(_semesterService);
                    error = semesterHandler.CanCheckSemester(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _semesterService.ActivateSemester(id);
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
        public async Task<IActionResult> DeleteSemester(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    SemesterHandler semesterHandler = new SemesterHandler(_semesterService);
                    error = semesterHandler.CanCheckSemester(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _semesterService.DeleteSemester(id);
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

        //url: api/Semester/getlist
        [HttpGet(Routes.GetList)]
        public async Task<IEnumerable<Semester>> GetSemesterList()
        {
            return await _semesterService.GetSemesters().ToListAsync();
        }

        [HttpGet(Routes.Get)]
        public async Task<IActionResult> GetSemester(int id)
        {
            Semester semester = null;
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    SemesterHandler semesterHandler = new SemesterHandler(_semesterService);
                    error = semesterHandler.CanCheckSemester(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        semester = _semesterService.GetSemesterById(id);
                        return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, semester));
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
