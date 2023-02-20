using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface IRoleService
    {
        IQueryable<Role> GetRoles();
        int AddRole(Role role);
        int UpdateRole(Role role);
        int ActivateRole(int roleId);
        int DeactivateRole(int roleId);
        int DeleteRole(int roleId);
        bool IsRoleExist(Role role);
        Role GetRole(int roleId);
    }
}
