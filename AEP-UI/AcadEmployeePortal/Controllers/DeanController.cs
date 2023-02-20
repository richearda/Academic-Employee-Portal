using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePortal.Controllers
{
    public class DeanController : Controller
    {

        public async Task<IActionResult> Login()
        {           
            return await Task.FromResult(View("~/Views/Login/Login.cshtml"));
        }
        public async Task<IActionResult> ViewCourseList()
        {
            ViewData["Header"] = "Manage Course";
            ViewData["MainHeader"] = "Course List";
            ViewData["Role"] = Convert.ToString(RouteData.Values["Controller"]);
            return await Task.FromResult(View("ManageCourses"));
        }
        public async Task<IActionResult> ManageTeachers()
        {
            ViewData["Header"] = "Manage Teacher";
            ViewData["MainHeader"] = "Teacher List";
            ViewData["Role"] = Convert.ToString(RouteData.Values["Controller"]);
            return await Task.FromResult(View("ManageTeachers"));
        }

        public async Task<IActionResult> ViewSChoolCalendar()
        {
            ViewData["Header"] = "Calendar of Activities";
            ViewData["Role"] = Convert.ToString(RouteData.Values["Controller"]);
            return await Task.FromResult(PartialView("~/Views/Shared/_SchoolCalendar.cshtml"));
        }
    }
}
