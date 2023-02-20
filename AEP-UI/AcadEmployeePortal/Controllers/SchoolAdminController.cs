using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePortal.Controllers
{
    public class SchoolAdminController : Controller
    {
        public async Task<IActionResult> ManageCalendar()
        {
            ViewData["Header"] = "Manage Calendar";
            ViewData["MainHeader"] = "List of Activities";
            ViewData["Role"] = Convert.ToString(RouteData.Values["Controller"]);
            //ViewData["Role"] = Convert.ToString(RouteData.Values["Controller"]);
            return await Task.FromResult(View("ManageCalendar"));
        }
    }
}
