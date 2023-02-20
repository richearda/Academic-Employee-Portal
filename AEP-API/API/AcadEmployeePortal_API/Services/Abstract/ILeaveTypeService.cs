using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveType>> GetLeaveTypes();
        int AddLeaveType(LeaveType leaveType);
        int UpdateLeaveType(LeaveType leaveType);
        //int ActivateLeaveApplication(int leaveApplicationId);
        //int DeactivateLeaveApplication(int leaveApplicationId);
        int DeleteLeaveType(int leaveApplicationId);
        //bool IsCourseExist(Course Course);
        LeaveType GetLeaveTypeById(int leaveApplicationId);
    }
}
