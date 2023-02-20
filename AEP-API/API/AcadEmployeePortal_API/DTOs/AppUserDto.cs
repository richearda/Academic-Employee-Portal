using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.DTOs
{
    public class AppUserDto
    {
        public int? PersonID { get; set; }
        public string PictureLink { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string College { get; set; }
        public string Token { get; set; }
    }
}
