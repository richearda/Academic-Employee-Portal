using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface IEmployeeScheduleService
    {
        //Task<IQueryable<EmployeeSchedule>> GetSchedulesAsync ();
        Task<int> AddEmployeeScheduleAsync(EmployeeSchedule employeeSchedule);
        Task<int> UpdateEmployeeScheduleAsync(EmployeeSchedule employeeSchedule);
        Task<int> DeleteEmployeeScheduleAsync(int employeeScheduleId);
        Task<bool> IsEmployeeScheduleExist(EmployeeSchedule employeeSchedule);
        Task<EmployeeSchedule> GetEmployeeScheduleAsync(int employeeScheduleId);
    }
}
