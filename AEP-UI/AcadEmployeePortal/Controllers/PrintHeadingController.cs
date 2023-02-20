using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePortal.Controllers
{
    public class PrintHeadingController : Controller
    {
        public IActionResult Index()
        {
            return PartialView("_PrintHeading_Layout");
        }
    }
}
