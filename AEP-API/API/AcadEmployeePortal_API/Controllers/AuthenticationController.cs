using ISMS_API.DTOs;
using ISMS_API.Helpers;
using ISMS_API.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ISMS_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AuthenticationController : Controller
    {
        
        private IAccountService _authenticationService;
        private IUserService _userService;

        public AuthenticationController(IAccountService authenticationService, IUserService userService)
        {
            _authenticationService = authenticationService;
            _userService = userService;
        }
        //Login Endpoint
        [HttpPost(Routes.Login)]
        public AppUserDto AuthenticateUser([FromBody] UserDto user)
        {
            
            return _authenticationService.AuthenticateUser(user);
                     
        }
    }
}
