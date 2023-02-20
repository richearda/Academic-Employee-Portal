using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public bool? IsActive { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<PersonUser> PersonUsers { get; set; }
    }
}
