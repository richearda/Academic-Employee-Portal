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
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpPost(Routes.Add)]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                try
                {
                    EmployeeHandler employeeHandler = new EmployeeHandler(_employeeService);
                    ValidationResult error = employeeHandler.CanAddEmployee(employee);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _employeeService.AddEmployee(employee);
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
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    EmployeeHandler employeeHandler = new EmployeeHandler(_employeeService);
                    error = employeeHandler.CanUpdateEmployee(employee);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _employeeService.UpdateEmployee(employee);
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
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            string message = "";
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    EmployeeHandler employeeHandler = new EmployeeHandler(_employeeService);
                    error = employeeHandler.CanCheckEmployee(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        int status = _employeeService.DeleteEmployee(id);
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

        //url: api/employee/getlist
        [HttpGet(Routes.GetList)]
        public async Task<IEnumerable<EmployeeDto>> GetEmployeeList()
        {
            return await _employeeService.GetEmployees();
        }

        [HttpGet(Routes.Get)]
        public async Task<IActionResult> GetEmployee(int id)
        {
            Employee employee = null;
            ValidationResult error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    EmployeeHandler EmployeeHandler = new EmployeeHandler(_employeeService);
                    error = EmployeeHandler.CanCheckEmployee(id);

                    if (error != null)
                        ModelState.AddModelError(error.Key, error.Message);
                    else
                    {
                        employee = _employeeService.GetEmployee(id);
                        return await Task.FromResult(ResponseHelper.ComposeResponse(ModelState, 200, employee));
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
