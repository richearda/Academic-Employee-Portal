using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using EmployeePortal.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace EmployeePortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //url: Home/Index
        //[HttpPost]
        public IActionResult Index(User user)
        {
          
            //HttpContext.Session.SetString['UserSession'] = user;
            //ViewData["PersonID"] = user.PersonId.ToString();
            //ViewData["PersonName"] = user.Name.ToString();
            //ViewData["Role"] = user.Role.ToString();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return await Task.FromResult(View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }));
        }

        public async Task<IActionResult> ReturnLayout()
        {
            return await Task.FromResult(PartialView("_Layout"));
        }
    }
}