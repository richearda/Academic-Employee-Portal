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
    public class CollegeController : ControllerBase
    {
        private ICollegeService _collegeService;

        public CollegeController(ICollegeService collegeService)
        {
            _collegeService = collegeService;
        }

        [HttpPost(Routes.Add)]
        public async Task<IActionResult> AddCollege([FromBody] College college)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                try
                {
                    CollegeHandler collegeHandler = new CollegeHandler(_collegeService);
                    ValidationResult error = collegeHandler.CanAddCollege(college);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _collegeService.AddCollege(college);
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
        public async Task<IActionResult> UpdateCollege([FromBody] College college)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    CollegeHandler collegeHandler = new CollegeHandler(_collegeService);
                    error = collegeHandler.CanUpdateCollege(college);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _collegeService.UpdateCollege(college);
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
        public async Task<IActionResult> DeactivateCollege(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    CollegeHandler collegeHandler = new CollegeHandler(_collegeService);
                    error = collegeHandler.CanCheckCollege(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _collegeService.DeactivateCollege(id);
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
        public async Task<IActionResult> ActivateCollege(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    CollegeHandler collegeHandler = new CollegeHandler(_collegeService);
                    error = collegeHandler.CanCheckCollege(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _collegeService.ActivateCollege(id);
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
        public async Task<IActionResult> DeleteCollege(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    CollegeHandler collegeHandler = new CollegeHandler(_collegeService);
                    error = collegeHandler.CanCheckCollege(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _collegeService.DeleteCollege(id);
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

        //url: api/college/getlist
        [HttpGet(Routes.GetList)]
        public async Task<IEnumerable<College>> GetCollegeList()
        {
            return await _collegeService.GetColleges().ToListAsync();
        }

        [HttpGet(Routes.Get)]
        public async Task<IActionResult> GetCollege(int id)
        {
            College college = null;
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    CollegeHandler collegeHandler = new CollegeHandler(_collegeService);
                    error = collegeHandler.CanCheckCollege(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        college = _collegeService.GetCollege(id);
                        return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, college));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                }
            }
            return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, error.StatusCode));
        }

        [HttpGet(Routes.GetList +"/Departments")]
        public List<CollegeDepartment> GetCollegeDepartments(string collegeName)
        {
            return _collegeService.GetCollegeDepartments(collegeName);
        }


    }
}