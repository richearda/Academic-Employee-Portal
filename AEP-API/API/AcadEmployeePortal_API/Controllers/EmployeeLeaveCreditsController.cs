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
    public class EmployeeLeaveCreditsController : Controller
    {
        private IEmployeeLeaveCreditsService _employeeLeaveCredits;
        public EmployeeLeaveCreditsController(IEmployeeLeaveCreditsService employeeLeaveCredits)
        {
            _employeeLeaveCredits = employeeLeaveCredits;
        }
        [HttpGet(Routes.Add)]
        public int AddEmployeeLeaveCredits([FromBody] EmployeeLeaveCredits employeeLeaveCredits)
        {
            return _employeeLeaveCredits.AddEmployeeLeaveCredits(employeeLeaveCredits);
        }
    }
}
