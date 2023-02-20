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
    public class LeaveTypeService : ILeaveTypeService
    {
        private EmpPortalDbContext _dbContext;
        public LeaveTypeService(EmpPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int AddLeaveType(LeaveType leaveType)
        {
             _dbContext.LeaveTypes.Add(leaveType);
            return _dbContext.SaveChanges();
        }

        public int DeleteLeaveType(int leaveTypeId)
        {
            LeaveType deleteType = _dbContext.LeaveTypes.AsNoTracking().Where(lt => lt.LeaveTypeId == leaveTypeId).FirstOrDefault();
            _dbContext.Entry(deleteType).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public Task<List<LeaveType>> GetLeaveTypes()
        {
            return _dbContext.LeaveTypes.ToListAsync();
        }
 
        public LeaveType GetLeaveTypeById(int leaveTypeId)
        {
            return _dbContext.LeaveTypes.AsNoTracking().Where(lt => lt.LeaveTypeId == leaveTypeId).FirstOrDefault();
        }

        public int UpdateLeaveType(LeaveType leaveType)
        {
            _dbContext.Entry(leaveType).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }
    }
}
