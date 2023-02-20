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
    public class EmployeeLeaveCreditsService : IEmployeeLeaveCreditsService
    {
        private EmpPortalDbContext _dbContext;
        public EmployeeLeaveCreditsService(EmpPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int AddEmployeeLeaveCredits(EmployeeLeaveCredits employeeLeaveCredits)
        {
            _dbContext.EmployeeLeaveCredits.Add(employeeLeaveCredits);
            return _dbContext.SaveChanges();
        }

        public int DeleteEmployeeLeaveCredits(int employeeLeaveCreditsId)
        {
            EmployeeLeaveCredits deleteLeaveCredits = _dbContext.EmployeeLeaveCredits.AsNoTracking().Where(l => l.EmployeeLeaveCreditsId == employeeLeaveCreditsId).FirstOrDefault();
            _dbContext.Entry(deleteLeaveCredits).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }
        public IQueryable<EmployeeLeaveCredits> GetEmployeeLeaveCredits()
        {
            return _dbContext.EmployeeLeaveCredits.AsNoTracking();
        }

        public int UpdateEmployeeEmployeeLeaveCredits(EmployeeLeaveCredits employeeLeaveCredits)
        {
            _dbContext.Entry(employeeLeaveCredits).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }
    }
}
