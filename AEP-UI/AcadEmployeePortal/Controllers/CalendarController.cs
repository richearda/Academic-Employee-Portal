using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePortal.Controllers
{
    public class CalendarController : Controller
    {

        public IActionResult ViewSchoolCalendar()
        {
            ViewData["Title"] = "School Calendar";
            ViewData["Header"] = "List of events";
            ViewData["MainHeader"] = "School Calendar";
            return PartialView("_SchoolCalendar");
        }
    }
}
