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
    public class GradeRemarksController : Controller
    {
        private IGradeRemarksService _gradeRemarksService;
        public GradeRemarksController(IGradeRemarksService gradeRemarksService)
        {
            _gradeRemarksService = gradeRemarksService;
        }

        [HttpPost(Routes.Add)]
        public async Task<IActionResult> AddGradeRemarks([FromBody] GradeRemarks gradeRemarks)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                try
                {
                    GradeRemarksHandler gradeRemarksHandler = new GradeRemarksHandler(_gradeRemarksService);
                    ValidationResult error = gradeRemarksHandler.CanAddGradeRemarks(gradeRemarks);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _gradeRemarksService.AddGradeRemarks(gradeRemarks);
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
        public async Task<IActionResult> UpdateGradeRemarks([FromBody] GradeRemarks gradeRemarks)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    GradeRemarksHandler gradeRemarksHandler = new GradeRemarksHandler(_gradeRemarksService);
                    error = gradeRemarksHandler.CanUpdateGradeRemarks(gradeRemarks);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _gradeRemarksService.UpdateGradeRemarks(gradeRemarks);
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
        public async Task<IActionResult> DeactivateGradeRemarks(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    GradeRemarksHandler gradeRemarksHandler = new GradeRemarksHandler(_gradeRemarksService);
                    error = gradeRemarksHandler.CanCheckGradeRemarks(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _gradeRemarksService.DeactivateGradeRemarks(id);
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
        public async Task<IActionResult> ActivateGradeRemarks(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    GradeRemarksHandler gradeRemarksHandler = new GradeRemarksHandler(_gradeRemarksService);
                    error = gradeRemarksHandler.CanCheckGradeRemarks(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _gradeRemarksService.ActivateGradeRemarks(id);
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
        public async Task<IActionResult> DeleteGradeRemarks(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    GradeRemarksHandler gradeRemarksHandler = new GradeRemarksHandler(_gradeRemarksService);
                    error = gradeRemarksHandler.CanCheckGradeRemarks(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _gradeRemarksService.DeleteGradeRemarks(id);
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

        //url: api/GradeRemarks/getlist
        [HttpGet(Routes.GetList)]
        public async Task<IEnumerable<GradeRemarks>> GetGradeRemarksList()
        {
            return await _gradeRemarksService.GetGradeRemarks().ToListAsync();
        }

        [HttpGet(Routes.Get)]
        public async Task<IActionResult> GetGradeRemarks(int id)
        {
            GradeRemarks gradeRemarks = null;
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    GradeRemarksHandler gradeRemarksHandler = new GradeRemarksHandler(_gradeRemarksService);
                    error = gradeRemarksHandler.CanCheckGradeRemarks(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        gradeRemarks = _gradeRemarksService.GetGradeRemarksById(id);
                        return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, gradeRemarks));
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
