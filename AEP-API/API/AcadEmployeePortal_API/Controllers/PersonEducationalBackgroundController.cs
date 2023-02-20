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
    public class PersonEducationalBackgroundController : Controller
    {
        private IPersonEducationalBackgroundService _personEducationaBackgroundService;
        public PersonEducationalBackgroundController(IPersonEducationalBackgroundService personEducationalBackgroundService)
        {
            _personEducationaBackgroundService = personEducationalBackgroundService;
        }
        [HttpPost(Routes.Add)]
        public int AddPersonEducationalBackground([FromBody] PersonEducationalBackground personEducationalBackground)
        {
            return _personEducationaBackgroundService.AddPersonEducationalBackground(personEducationalBackground);
        }
    }
}
