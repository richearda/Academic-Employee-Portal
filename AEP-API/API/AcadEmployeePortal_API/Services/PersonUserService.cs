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
    public class PersonUserService : IPersonUserService
    {
        private EmpPortalDbContext _dbContext;
        public PersonUserService(EmpPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public PersonUser GetPersonByUserId(int userId)
        {
            return _dbContext.PersonUsers.Include(pu => pu.Person).Where(pu => pu.UserId == userId).FirstOrDefault();
        }
    }
}
