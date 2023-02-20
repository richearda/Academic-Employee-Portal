using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePortal.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ILogger<TeacherController> _logger;

        public TeacherController(ILogger<TeacherController> logger)
        {
            _logger = logger;
        }


        public async Task<IActionResult> TeacherCourseList()
        {
            
            ViewData["Header"] = "List of Courses";
            ViewData["MainHeader"] = "Courses";
            ViewData["Role"] = Convert.ToString(RouteData.Values["Controller"]);
            return await Task.FromResult(View("TeacherCourseList"));          
        }

        public async Task<IActionResult> CourseStudentList()
        {
            ViewData["Header"] = "Student Masterlist";
            ViewData["Role"] = Convert.ToString(RouteData.Values["Controller"]);
            return await Task.FromResult(View("CourseStudentList"));
        }
        public async Task<IActionResult> ViewStudentInfo()
        {
            ViewData["Header"] = "View Student";
            ViewData["Role"] = Convert.ToString(RouteData.Values["Controller"]);
            return await Task.FromResult(View("StudentInfo"));
        }
        public async Task<IActionResult> ViewSChoolCalendar()
        {
            ViewData["Header"] = "Calendar of Activities";
            ViewData["MainHeader"] = "School Calendar";
            ViewData["Role"] = Convert.ToString(RouteData.Values["Controller"]);
            return await Task.FromResult(PartialView("~/Views/Shared/_SchoolCalendar.cshtml"));
        }

        //public async Task<IActionResult> ApplyLeave()
        //{
        //    ViewData["Header"] = "Apply for a Leave";
        //    ViewData["Role"] = Convert.ToString(RouteData.Values["Controller"]);
        //    return await Task.FromResult(View("EmployeeLeave/LeaveApplicationForm"));
        //}
    }
}
