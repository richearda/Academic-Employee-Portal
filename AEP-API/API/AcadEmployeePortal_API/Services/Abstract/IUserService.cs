using ISMS_API.DTOs;
using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface IUserService
    {
        IQueryable<User> GetUsers();
        int AddUser(User User);
        int UpdateUser(User User);
        int ActivateUser(int ID);
        int DeactivateUser(int ID);
        int DeleteUser(int ID);
        bool IsUserExist(User User);
        User GetUser(int ID);
        AppUserDto GetUserDetails(string username, string password);
    }
}
