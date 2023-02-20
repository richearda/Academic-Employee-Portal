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
    public class LeaveApplicationService : ILeaveApplicationService
    {
        private EmpPortalDbContext _dbContext;
        public LeaveApplicationService(EmpPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddLeaveApplication(LeaveApplication leaveApplication)
        {
            _dbContext.LeaveApplications.Add(leaveApplication);
            return _dbContext.SaveChanges();
        }


        public int DeleteLeaveApplication(int leaveApplicationId)
        {
            LeaveApplication deleteApp = _dbContext.LeaveApplications.AsNoTracking().Where(la => la.LeaveApplicationId == leaveApplicationId).FirstOrDefault();
            _dbContext.Entry(deleteApp).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public LeaveApplication GetLeaveApplication(int leaveApplicationId)
        {
            return _dbContext.LeaveApplications.AsNoTracking().Where(la => la.LeaveApplicationId == leaveApplicationId).FirstOrDefault();
        }

        public Task<List<LeaveApplication>> GetLeaveApplications()
        {
            return _dbContext.LeaveApplications.ToListAsync();
        }

        public int UpdateLeaveApplication(LeaveApplication leaveApplication)
        {
            _dbContext.Entry(leaveApplication).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }
    }
}
