using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface IEmployeeLeaveCreditsService
    {
        int AddEmployeeLeaveCredits(EmployeeLeaveCredits employeeLeaveCredits);
        int UpdateEmployeeEmployeeLeaveCredits(EmployeeLeaveCredits employee);
        int DeleteEmployeeLeaveCredits(int employeeID);
        IQueryable<EmployeeLeaveCredits> GetEmployeeLeaveCredits();
        //IQueryable<EmployeeLeaveCredits> GetEmployeeLeaveCreditsById(int employeeID);
        //bool IsEmployeeExist(Employee employee);
    }
}
