using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePortal.Controllers
{
    public class EmployeeLeaveController : Controller
    {
        public async Task<IActionResult> ApplyLeave()
        {
            return await Task.FromResult(View("LeaveApplicationForm"));
        }
    }
}
