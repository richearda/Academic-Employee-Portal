using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface ILeaveApplicationService
    {
        Task<List<LeaveApplication>> GetLeaveApplications();
        int AddLeaveApplication(LeaveApplication leaveApplication);
        int UpdateLeaveApplication(LeaveApplication leaveApplication);
        //int ActivateLeaveApplication(int leaveApplicationId);
        //int DeactivateLeaveApplication(int leaveApplicationId);
        int DeleteLeaveApplication(int leaveApplicationId);
        //bool IsCourseExist(Course Course);
        LeaveApplication GetLeaveApplication(int leaveApplicationId);
    }
}
