using ISMS_API.Handlers;
using ISMS_API.Helpers;
using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EmployeeScheduleController : Controller
    {
        
            private IEmployeeScheduleService _employeeScheduleService;

            public EmployeeScheduleController(IEmployeeScheduleService employeeScheduleService)
            {
                _employeeScheduleService = employeeScheduleService;
            }

            [HttpPost(Routes.Add)]
            public async Task<IActionResult> AddEmployeeSchedule([FromBody] EmployeeSchedule employeeSchedule)
            {
                string message = "";

                if (ModelState.IsValid)
                {
                    try
                    {
                        EmployeeScheduleHandler employeeScheduleHandler = new EmployeeScheduleHandler(_employeeScheduleService);
                        ValidationResult error = await employeeScheduleHandler.CanAddEmployeeSchedule(employeeSchedule);

                        if (error != null)
                            ModelState.AddModelError(error.Key, error.Message);
                        else
                        {
                            int status = await _employeeScheduleService.AddEmployeeScheduleAsync(employeeSchedule);
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
            public async Task<IActionResult> UpdateEmployeeSchedule([FromBody] EmployeeSchedule employeeSchedule)
            {
                string message = "";
                ValidationResult error = null;

                if (ModelState.IsValid)
                {
                    try
                    {
                        EmployeeScheduleHandler employeeScheduleHandler = new EmployeeScheduleHandler(_employeeScheduleService);
                        error = await employeeScheduleHandler.CanUpdateEmployeeSchedule(employeeSchedule);

                        if (error != null)
                            ModelState.AddModelError(error.Key, error.Message);
                        else
                        {
                            int status = await _employeeScheduleService.UpdateEmployeeScheduleAsync(employeeSchedule);
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

         

            [HttpDelete(Routes.Delete)]
            public async Task<IActionResult> DeleteEmployeeSchedule(int employeeScheduleId)
            {
                string message = "";
                ValidationResult error = null;

                if (ModelState.IsValid)
                {
                    try
                    {
                        EmployeeScheduleHandler employeeScheduleHandler = new EmployeeScheduleHandler(_employeeScheduleService);
                        error = await employeeScheduleHandler.CanCheckEmployeeSchedule(employeeScheduleId);

                        if (error != null)
                            ModelState.AddModelError(error.Key, error.Message);
                        else
                        {
                            int status = await _employeeScheduleService.DeleteEmployeeScheduleAsync(employeeScheduleId);
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

           
            [HttpGet(Routes.Get)]
            public async Task<IActionResult> GetEmployeeSchedule(int employeeScheduleId)
            {
                EmployeeSchedule employeeSchedule = null;
                ValidationResult error = null;

                if (ModelState.IsValid)
                {
                    try
                    {
                        EmployeeScheduleHandler employeeScheduleHandler = new EmployeeScheduleHandler(_employeeScheduleService);
                        error = await employeeScheduleHandler.CanCheckEmployeeSchedule(employeeScheduleId);

                        if (error != null)
                            ModelState.AddModelError(error.Key, error.Message);
                        else
                        {
                            employeeSchedule = await _employeeScheduleService.GetEmployeeScheduleAsync(employeeScheduleId);
                            return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, employeeSchedule));
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
