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
    public class EmployeeScheduleService : IEmployeeScheduleService
    {
        private EmpPortalDbContext _dbContext;
        public EmployeeScheduleService(EmpPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddEmployeeScheduleAsync(EmployeeSchedule employeeSchedule)
        {
            await _dbContext.EmployeeSchedules.AddAsync(employeeSchedule);
            return  await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteEmployeeScheduleAsync(int employeeScheduleId)
        {
            EmployeeSchedule deleteSched = await _dbContext.EmployeeSchedules.AsNoTracking().Where(e => e.EmployeeScheduleId == employeeScheduleId).FirstOrDefaultAsync();
            _dbContext.Entry(deleteSched).State = EntityState.Deleted;
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<EmployeeSchedule> GetEmployeeScheduleAsync(int employeeScheduleId)
        {
            return await _dbContext.EmployeeSchedules.AsNoTracking().Where(e => e.EmployeeScheduleId == employeeScheduleId).FirstOrDefaultAsync();
        }

        public Task<IQueryable<EmployeeSchedule>> GetEmployeeSchedulesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsEmployeeScheduleExist(EmployeeSchedule employeeSchedule)
        {
            EmployeeSchedule isExist = await _dbContext.EmployeeSchedules.AsNoTracking().Where(e => e.EmployeeScheduleId == employeeSchedule.EmployeeScheduleId).FirstOrDefaultAsync();
            return (isExist != null);
        }

        public async Task<int> UpdateEmployeeScheduleAsync(EmployeeSchedule employeeSchedule)
        {
             _dbContext.Entry(employeeSchedule).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }
    }
}
