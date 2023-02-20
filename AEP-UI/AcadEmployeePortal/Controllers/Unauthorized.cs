using Microsoft.AspNetCore.Mvc;
using System;

namespace EmployeePortal.Controllers
{
    public class Unauthorized : Controller
    {
        public IActionResult ReturnUnauthorizedPage()
        {
            ViewData["InitPath"] = Convert.ToString(RouteData.Values["Controller"]);
            return View("Unauthorized");
        }
    }
}
