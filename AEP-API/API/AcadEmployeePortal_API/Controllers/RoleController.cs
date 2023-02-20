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
    public class RoleController : Controller
    {

        private IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpPost(Routes.Add)]
        public int AddRole([FromBody] Role role)
        {
            return _roleService.AddRole(role);
        }
        [HttpPut(Routes.Edit)]
        public int UpdateRole([FromBody] Role role)
        {
            return _roleService.UpdateRole(role);
        }
        [HttpDelete(Routes.Delete)]
        public int DeleteRole([FromBody] int roleId)
        {
            return _roleService.DeleteRole(roleId);
        }
        [HttpGet(Routes.Get)]
        public Role GetRole([FromBody] int roleId)
        {
            return _roleService.GetRole(roleId);
        }
        [HttpGet(Routes.GetList)]
        public IQueryable<Role> GetRoles()
        {
            return _roleService.GetRoles();
        }
        [HttpPut(Routes.Activate)]
        public int ActivateRole(int roleId)
        {
            return _roleService.ActivateRole(roleId);
        }
        [HttpPut(Routes.Deactivate)]
        public int DeactivateRole(int roleId)
        {
            return _roleService.DeactivateRole(roleId);
        }
    }
}
