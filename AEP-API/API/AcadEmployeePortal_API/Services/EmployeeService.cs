using AutoMapper;
using AutoMapper.QueryableExtensions;
using ISMS_API.Data;
using ISMS_API.DTOs;
using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private EmpPortalDbContext _dbContext;
        private IMapper _mapper;
        public EmployeeService(EmpPortalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
   

        public int AddEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            return _dbContext.SaveChanges();
        }


        public int DeleteEmployee(int employeeID)
        {
            Employee deleteEmployee =_dbContext.Employees.Where(e => e.EmployeeId == employeeID).FirstOrDefault();
            _dbContext.Entry(deleteEmployee).State = EntityState.Deleted;
            return _dbContext.SaveChanges();

        }

        public Employee GetEmployee(int employeeID)
        {
            return _dbContext.Employees.Include(e => e.Person).Where(e => e.EmployeeId == employeeID).FirstOrDefault();
        }

        public async Task<IQueryable<EmployeeDto>> GetEmployees()
        {
            //var employees = await _dbContext.Employees.Include(e => e.Person).ProjectTo<EmployeeDto>(_mapper.Map<EmployeeDto>(employees).ToListAsync());

            var employees = await _dbContext.Employees
                    .Include(e => e.Person)
                        .ThenInclude(p => p.Gender)
                    .Include(e => e.DesignationStatus)
                    .Include(e => e.EmployeeClassification).AsQueryable().ToListAsync();
            return _mapper.ProjectTo<EmployeeDto>(_mapper.Map<IQueryable<EmployeeDto>>(employees));
          // return _mapper.Map<IQueryable<EmployeeDto>>(employees);
            
        }

        public bool IsEmployeeExist(Employee employee)
        {
            Employee employeeId = _dbContext.Employees.Where(e => e.EmployeeId == employee.EmployeeId).FirstOrDefault();
            return (employeeId != null);
        }

        public int UpdateEmployee(Employee employee)
        {
            _dbContext.Entry(employee).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

     
    }
}
