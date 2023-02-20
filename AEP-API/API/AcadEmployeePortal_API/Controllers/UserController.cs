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
    public class UserController : Controller
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost(Routes.Add)]
        public int AddUser([FromBody] User user)
        {
            return _userService.AddUser(user);
        }
        [HttpPut(Routes.Edit)]
        public int UpdateUser([FromBody] User user)
        {
            return _userService.UpdateUser(user);
        }
        [HttpDelete(Routes.Delete)]
        public int DeleteUser([FromBody] int userId)
        {
            return _userService.DeleteUser(userId);
        }
        [HttpPost(Routes.Activate)]
        public int ActivateUser(int userId)
        {
            return _userService.ActivateUser(userId);
        }
        [HttpPost(Routes.Deactivate)]
        public int DeactivateUser([FromBody] int userId)
        {
            return _userService.DeactivateUser(userId);
        }
        [HttpGet(Routes.Get)]
        public User GetUser([FromBody] int userId)
        {
            return _userService.GetUser(userId);
        }
        [HttpGet(Routes.GetList)]
        public IQueryable<User> GetUsers()
        {
            return _userService.GetUsers();
        }
        [HttpGet(Routes.GetList + "/GetDetails")]

        public AppUserDto GetUserDetails(string username, string password)
        {
            return _userService.GetUserDetails(username, password);
        }



    }
}
