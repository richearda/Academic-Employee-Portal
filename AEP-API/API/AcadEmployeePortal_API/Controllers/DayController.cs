using ISMS_API.Data;
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
    public class DayController : Controller
    {
        
        private IDayService _dayService;
        public DayController(IDayService dayService)
        {
            _dayService = dayService;
        }
        [HttpGet(Routes.GetList)]
        public IEnumerable<Day> GetDays()
        {
            return _dayService.GetDays();
            //return View();
        }
    }
}
