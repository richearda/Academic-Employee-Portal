using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.DTOs
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }       
        public string Password { get; set; }
        //public PersonDto Person { get; set; }
        //public int RoleId { get; set; }
    }
}
