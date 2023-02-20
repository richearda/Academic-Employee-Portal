using ISMS_API.DTOs;
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
    public class DeanController : Controller
    {
        private IDeanService _deanService;
        public DeanController(IDeanService deanService)
        {
            _deanService = deanService;
        }
        [HttpPost(Routes.Add)]
        public int AddDean([FromBody] Dean dean)
        {
            return _deanService.AddDean(dean);
        }
        [HttpPut(Routes.Edit)]
        public int UpdateDean([FromBody] Dean dean)
        {
            return _deanService.UpdateDean(dean);
        }
        [HttpDelete(Routes.Delete)]
        public int DeleteDean(int deanId)
        {
            return _deanService.DeleteDean(deanId);
        }
        [HttpGet(Routes.GetDeanByPersonId)]
        public Dean GetDeanByPersonId(int personId)
        {
            return _deanService.GetDeanByPersonId(personId);
        }

        [HttpGet(Routes.GetList)]
        public ICollection<DeanDto> GetTeacherList()
        {
            return _deanService.GetDeans();
        }
    }
}
