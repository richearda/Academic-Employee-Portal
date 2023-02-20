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
    public class LeaveApplicationStatusService : ILeaveApplicationStatusService
    {
        private EmpPortalDbContext _dbContext;
        public LeaveApplicationStatusService(EmpPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int AddLeaveApplicationStatus(LeaveApplicationStatus leaveApplicationStatus)
        {
            _dbContext.LeaveApplicationStatus.Add(leaveApplicationStatus);
            return _dbContext.SaveChanges();
        }

        public int DeleteLeaveApplicationStatus(int leaveApplicationId)
        {
            LeaveApplicationStatus deleteAppStatus = _dbContext.LeaveApplicationStatus.AsNoTracking().Where(s => s.ApplicationStatusId == leaveApplicationId).FirstOrDefault();
            _dbContext.Entry(deleteAppStatus).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public LeaveApplicationStatus GetLeaveApplicationStatusById(int leaveApplicationId)
        {
            return _dbContext.LeaveApplicationStatus.AsNoTracking().Where(s => s.ApplicationStatusId == leaveApplicationId).FirstOrDefault();
        }

        public Task<List<LeaveApplicationStatus>> GetLeaveApplicationStatus()
        {
            return _dbContext.LeaveApplicationStatus.ToListAsync();
        }

        public int UpdateLeaveApplicationStatus(LeaveApplicationStatus leaveApplicationStatus)
        {
            _dbContext.Entry(leaveApplicationStatus).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }
    }
}
