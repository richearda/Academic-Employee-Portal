 using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePortal.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            ViewData["InitPath"] = Convert.ToString(RouteData.Values["Controller"]);
            return View();
        }
    }
}
