using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Handlers
{
    public class EmployeeClassificationHandler
    {
        private IEmployeeClassificationService _employeeClassificationService;
        public EmployeeClassificationHandler(IEmployeeClassificationService employeeClassificationService)
        {
            _employeeClassificationService = employeeClassificationService;
        }
        public ValidationResult CanAddEmployeeClassification(EmployeeClassification employeeClassification)
        {
            ValidationResult result = null;
            if (employeeClassification.EmployeeClassificationDescription != null && employeeClassification.EmployeeClassificationDescription != "")
            {
               
                    if (_employeeClassificationService.IsEmployeeClassificationExist(employeeClassification))
                        result = new ValidationResult("EmployeeClassificationDescription", "Already existing", 400);                            
            }
            else
                result = new ValidationResult("EmployeeClassificationDescription", "Required", 400);
            return result;
        }

        public ValidationResult CanUpdateEmployeeClassification(EmployeeClassification employeeClassification)
        {
            ValidationResult result = null;
            EmployeeClassification checkEmployeeClassification = _employeeClassificationService.GetEmployeeClassification(employeeClassification.EmployeeClassificationID);

            if (checkEmployeeClassification != null)
            {
                if (employeeClassification.EmployeeClassificationDescription == null || employeeClassification.EmployeeClassificationDescription == "")
                    result = new ValidationResult("EmployeeClassificationDescription", "Required", 400);
                else if ((employeeClassification.EmployeeClassificationDescription.Equals(checkEmployeeClassification.EmployeeClassificationDescription)))
                {
                    if (_employeeClassificationService.IsEmployeeClassificationExist(employeeClassification))
                        result = new ValidationResult("EmployeeClassification", "Already existing", 400);
                }
            }
            else
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }


        public ValidationResult CanCheckEmployeeClassification(int ID)
        {
            ValidationResult result = null;
            EmployeeClassification employee = _employeeClassificationService.GetEmployeeClassification(ID);
            if (employee == null)
                result = new ValidationResult("Error", "Employee does not exist.", 404);
            return result;
        }


    


}
}
