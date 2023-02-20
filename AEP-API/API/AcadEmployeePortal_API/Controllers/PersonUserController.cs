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
    public class PersonUserController : Controller
    {
        private IPersonUserService _personUserService;
        public PersonUserController(IPersonUserService personUserService)
        {
            _personUserService = personUserService;
        }
        [HttpGet(Routes.Get)]
        public PersonUser GetPersonByUserId(int userId)
        {
            return _personUserService.GetPersonByUserId(userId);
        }
    }
}
