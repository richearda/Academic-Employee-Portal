using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Handlers
{
    public class EmployeeHandler
    {
        private IEmployeeService _employeeService;
        public EmployeeHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        public ValidationResult CanAddEmployee(Employee employee)
        {
            ValidationResult result = null;
            if (employee.EmployeeNo != null && employee.EmployeeNo != "")
            {
                if ((employee.PersonId > 0 || employee.EmployeeClassificationId > 0 || employee.DesignationStatusId > 0))
                {
                    if (_employeeService.IsEmployeeExist(employee))
                        result = new ValidationResult("EmployeeNo", "Already existing", 400);
                }
                else
                    result = new ValidationResult("ReferenceId", "Missing reference Id", 400);
            }
            else
                result = new ValidationResult("EmployeeNo", "Required", 400);
            return result;
        }

        public ValidationResult CanUpdateEmployee(Employee employee)
        {
            ValidationResult result = null;
            Employee checkEmployee = _employeeService.GetEmployee(employee.EmployeeId);

            if (checkEmployee != null)
            {
                if (employee.EmployeeNo == null || employee.EmployeeNo == "")
                    result = new ValidationResult("EmployeeNo", "Required", 400);
                else if ((employee.PersonId <= 0 || employee.EmployeeClassificationId <= 0 || employee.DesignationStatusId <= 0))
                    result = new ValidationResult("ID", "Required", 400);
                else if ((employee.EmployeeNo.Equals(checkEmployee.EmployeeNo)))
                {
                    if (_employeeService.IsEmployeeExist(employee))
                        result = new ValidationResult("EmployeeNo", "Already existing", 400);
                }
            }
            else
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }

        
        public ValidationResult CanCheckEmployee(int Id)
        {
            ValidationResult result = null;
            Employee employee = _employeeService.GetEmployee(Id);
            if (employee == null)
                result = new ValidationResult("Error", "Employee does not exist.", 404);
            return result;
        }


    }
}
