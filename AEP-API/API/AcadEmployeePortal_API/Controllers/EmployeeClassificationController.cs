using ISMS_API.Handlers;
using ISMS_API.Helpers;
using ISMS_API.Models;
using ISMS_API.Services;
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
    public class EmployeeClassificationController : Controller
    {
        private IEmployeeClassificationService _employeeClassificationService;
        public EmployeeClassificationController(IEmployeeClassificationService employeeClassificationService)
        {
            _employeeClassificationService = employeeClassificationService;
        }

        [HttpPost(Routes.Add)]
        public async Task<IActionResult> AddEmployeeClassification([FromBody] EmployeeClassification employeeClassification)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                try
                {
                    EmployeeClassificationHandler employeeClassificationHandler = new EmployeeClassificationHandler(_employeeClassificationService);
                    ValidationResult error = employeeClassificationHandler.CanAddEmployeeClassification(employeeClassification);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _employeeClassificationService.AddEmployeeClassification(employeeClassification);
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
        public async Task<IActionResult> UpdateEmployeeClassification([FromBody] EmployeeClassification EmployeeClassification)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    EmployeeClassificationHandler EmployeeClassificationHandler = new EmployeeClassificationHandler(_employeeClassificationService);
                    error = EmployeeClassificationHandler.CanUpdateEmployeeClassification(EmployeeClassification);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _employeeClassificationService.UpdateEmployeeClassification(EmployeeClassification);
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
        public async Task<IActionResult> DeactivateEmployeeClassification(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    EmployeeClassificationHandler EmployeeClassificationHandler = new EmployeeClassificationHandler(_employeeClassificationService);
                    error = EmployeeClassificationHandler.CanCheckEmployeeClassification(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _employeeClassificationService.DeactivateEmployeeClassification(id);
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
        public async Task<IActionResult> ActivateEmployeeClassification(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    EmployeeClassificationHandler EmployeeClassificationHandler = new EmployeeClassificationHandler(_employeeClassificationService);
                    error = EmployeeClassificationHandler.CanCheckEmployeeClassification(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _employeeClassificationService.ActivateEmployeeClassification(id);
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
        public async Task<IActionResult> DeleteEmployeeClassification(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    EmployeeClassificationHandler EmployeeClassificationHandler = new EmployeeClassificationHandler(_employeeClassificationService);
                    error = EmployeeClassificationHandler.CanCheckEmployeeClassification(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _employeeClassificationService.DeleteEmployeeClassification(id);
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

        //url: api/EmployeeClassification/getlist
        [HttpGet(Routes.GetList)]
        public async Task<IEnumerable<EmployeeClassification>> GetEmployeeClassificationList()
        {
            return await _employeeClassificationService.GetEmployeeClassifications().ToListAsync();
        }

        [HttpGet(Routes.Get)]
        public async Task<IActionResult> GetEmployeeClassification(int id)
        {
            EmployeeClassification EmployeeClassification = null;
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    EmployeeClassificationHandler EmployeeClassificationHandler = new EmployeeClassificationHandler(_employeeClassificationService);
                    error = EmployeeClassificationHandler.CanCheckEmployeeClassification(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        EmployeeClassification = _employeeClassificationService.GetEmployeeClassification(id);
                        return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, EmployeeClassification));
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
