using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class Menu
    {
        public int MenuId { get; set; }
        public int? OrderNo { get; set; }
        public int? ParentMenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuLink { get; set; }
        public string MenuIcon { get; set; }
        public bool? IsActive { get; set; }

        public virtual Menu ParentMenu { get; set; }
        public virtual ICollection<Menu> InverseParentMenu { get; set; }
        public virtual ICollection<RoleMenu> RoleMenus { get; set; }
    }
}
