using ISMS_API.DTOs;
using ISMS_API.Helpers;
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
    public class CurriculumController : Controller
    {
        private ICurriculumService _curriculumService;
        public CurriculumController(ICurriculumService curriculumService)
        {
            _curriculumService = curriculumService;
        }
        [HttpGet(Routes.GetList)]
        public List<CourseDto> GetCurriculumCourses([FromQuery]string curriculumName)
        {
           return _curriculumService.GetCurriculumCourses(curriculumName);
        } 
    }
}
