using AutoMapper;
using ISMS_API.Data;
using ISMS_API.DTOs;
using ISMS_API.Helpers;
using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services
{
    public class UserService : IUserService
    {
        private EmpPortalDbContext _dbContext;
        private IPersonUserService _personUserService;
        private IRoleService _roleService;
        private IMapper _mapper;
        public UserService(EmpPortalDbContext dbContext, IPersonUserService personUserService, IRoleService roleService, IMapper mapper)
        {
            _dbContext = dbContext;
            _personUserService = personUserService;
            _roleService = roleService;
            _mapper = mapper;
        }
        public int ActivateUser(int userId)
        {
            User activateUser = _dbContext.Users.AsNoTracking().Where(u => u.UserId == userId).FirstOrDefault();
            activateUser.IsActive = true;
            _dbContext.Entry(activateUser).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int AddUser(User user)
        {
            user.Password = CryptographyHelper.GenerateHash(user.Password);                     
            _dbContext.Users.Add(user);
            return _dbContext.SaveChanges();
        }

        public int DeactivateUser(int userId)
        {
            User deactivateUser = _dbContext.Users.AsNoTracking().Where(u => u.UserId == userId).FirstOrDefault();
            deactivateUser.IsActive = false;
            _dbContext.Entry(deactivateUser).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeleteUser(int userId)
        {
            User deleteUser = _dbContext.Users.AsNoTracking().Where(u => u.UserId == userId).FirstOrDefault();
            _dbContext.Entry(deleteUser).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public User GetUser(int userId)
        {
            return _dbContext.Users.AsNoTracking().Where(u => u.UserId == userId).FirstOrDefault();
        }

        public IQueryable<User> GetUsers()
        {
            return _dbContext.Users.AsNoTracking().Where(u => u.IsActive == true);
        }

        public bool IsUserExist(User user)
        {
            User userExist = _dbContext.Users.AsNoTracking().Where(u => u.Username == user.Username).FirstOrDefault();
            return (userExist != null);
        }

        public int UpdateUser(User User)
        {
            _dbContext.Entry(User).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public AppUserDto GetUserDetails(string username, string password)
        {
            string passwordHash = CryptographyHelper.GenerateHash(password);
            User userDetails = _dbContext.Users.Where(u => u.Username == username && u.Password == passwordHash).FirstOrDefault();
            Role userRole = _roleService.GetRole(userDetails.RoleId);
            PersonUser userPerson = _personUserService.GetPersonByUserId(userDetails.UserId);

            var appUser = new AppUserDto()
            {
                PersonID = userPerson.PersonId,
                Name = userPerson.Person.FirstName + " " + userPerson.Person.LastName + " " + (userPerson.Person.MiddleName == null ? "" : userPerson.Person.MiddleName),
                Role = userRole.RoleName
            };
            return appUser;
        }
    }
}
