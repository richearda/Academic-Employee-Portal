using ISMS_API.DTOs;
using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface IEmployeeService
    {

        int AddEmployee(Employee employee);
        int UpdateEmployee(Employee employee);
        int DeleteEmployee(int employeeID);
        Task<IQueryable<EmployeeDto>> GetEmployees();
        Employee GetEmployee(int employeeID);
        bool IsEmployeeExist(Employee employee);


    }
}
