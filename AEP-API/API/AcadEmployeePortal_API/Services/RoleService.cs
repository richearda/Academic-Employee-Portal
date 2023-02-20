using ISMS_API.Data;
using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services
{
    public class RoleService : IRoleService
    {
        private EmpPortalDbContext _dbContext;
        public RoleService(EmpPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int ActivateRole(int roleId)
        {
            Role activateRole = _dbContext.Roles.AsNoTracking().Where(r => r.RoleId == roleId).FirstOrDefault();
            activateRole.IsActive = true;
            _dbContext.Entry(activateRole).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int AddRole(Role role)
        {
             _dbContext.Roles.Add(role);
            return _dbContext.SaveChanges();
        }

        public int DeactivateRole(int roleId)
        {
            Role deactivateRole = _dbContext.Roles.AsNoTracking().Where(r => r.RoleId == roleId).FirstOrDefault();
            deactivateRole.IsActive = false;
            _dbContext.Entry(deactivateRole).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeleteRole(int roleId)
        {
            Role deleteRole = _dbContext.Roles.AsNoTracking().Where(r => r.RoleId == roleId).FirstOrDefault();
            _dbContext.Entry(deleteRole).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public Role GetRole(int roleId)
        {
            return _dbContext.Roles.AsNoTracking().Where(r => r.RoleId == roleId).FirstOrDefault();
        }

        public IQueryable<Role> GetRoles()
        {
            return _dbContext.Roles.AsNoTracking().Where(r => r.IsActive == true);
        }

        public bool IsRoleExist(Role role)
        {
            Role roleExist = _dbContext.Roles.AsNoTracking().Where(r => r.RoleName == role.RoleName).FirstOrDefault();
            return (roleExist != null);
        }

        public int UpdateRole(Role role)
        {
            _dbContext.Entry(role).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }
    }
}
