using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool? IsActive { get; set; }

        //public virtual ICollection<RoleMenu> RoleMenus { get; set; }
        //public virtual ICollection<RoleProject> RoleProjects { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
