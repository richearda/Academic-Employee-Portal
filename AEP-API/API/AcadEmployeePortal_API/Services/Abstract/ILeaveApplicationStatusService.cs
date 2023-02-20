using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface ILeaveApplicationStatusService
    {
        Task<List<LeaveApplicationStatus>> GetLeaveApplicationStatus();
        int AddLeaveApplicationStatus(LeaveApplicationStatus leaveApplication);
        int UpdateLeaveApplicationStatus(LeaveApplicationStatus leaveApplication);
        //int ActivateLeaveApplication(int leaveApplicationId);
        //int DeactivateLeaveApplication(int leaveApplicationId);
        int DeleteLeaveApplicationStatus(int leaveApplicationId);
        //bool IsCourseExist(Course Course);
        LeaveApplicationStatus GetLeaveApplicationStatusById(int leaveApplicationId);
    }
}
