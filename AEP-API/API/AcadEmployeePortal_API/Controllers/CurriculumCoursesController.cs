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
    public class CurriculumCoursesController : Controller
    {
        private ICurriculumCourseService _curriculumCourseService;

        public CurriculumCoursesController(ICurriculumCourseService curriculumCourseService)
        {
            _curriculumCourseService = curriculumCourseService;
        }

        [HttpGet(Routes.GetList)]
        public List<CurriculumCourseDto> GetCurriculumCourses()
        {
            return _curriculumCourseService.GetCurriculumCourses();
        }
        [HttpGet(Routes.GetList + "/courses")]
        public List<CurriculumCourseDto> GetCoursesByCurriculum(string curriculumName)
        {
            return _curriculumCourseService.GetCoursesByCurriculum(curriculumName);
        }
    }
}
