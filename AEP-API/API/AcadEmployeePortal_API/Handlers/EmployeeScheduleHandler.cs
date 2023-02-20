using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Handlers
{
    public class EmployeeScheduleHandler
    {
        private IEmployeeScheduleService _employeeScheduleService;

        public EmployeeScheduleHandler(IEmployeeScheduleService employeeScheduleService)
        {
            _employeeScheduleService = employeeScheduleService;
        }

        public async Task<ValidationResult> CanAddEmployeeSchedule(EmployeeSchedule employeeSchedule)
        {
            ValidationResult result = null;

            if (employeeSchedule.EmployeeId != 0 || employeeSchedule.EmployeeId < 0)
            {
                if (await _employeeScheduleService.IsEmployeeScheduleExist(employeeSchedule))
                    result = new ValidationResult("EmployeeScheduleName", "Already existing", 400);
            }
            else
                result = new ValidationResult("EmployeeScheduleID", "Required", 400);

            return result;
        }

        public async Task<ValidationResult> CanUpdateEmployeeSchedule(EmployeeSchedule employeeSchedule)
        {
            ValidationResult result = null;
            EmployeeSchedule origEmployeeSchedule = await _employeeScheduleService.GetEmployeeScheduleAsync(employeeSchedule.EmployeeScheduleId);

            if (origEmployeeSchedule != null)
            {
                if (employeeSchedule.TimeStart == null && employeeSchedule.MidDayTimeStart <= 0)
                    result = new ValidationResult("Employee Time Start", "Required", 400);
                else if (employeeSchedule.TimeEnd == null && employeeSchedule.MidDayTimeEnd <= 0)
                    result = new ValidationResult("Employee Time End", "Required", 400);
                else if ((employeeSchedule.Equals(origEmployeeSchedule)))
                {
                    if (await _employeeScheduleService.IsEmployeeScheduleExist(employeeSchedule))
                        result = new ValidationResult("Employee Schedule", "Already existing", 400);
                }
            }
            else
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }

        public async Task<ValidationResult> CanCheckEmployeeSchedule(int employeeScheduleId)
        {
            ValidationResult result = null;
            EmployeeSchedule employeeSchedule = await _employeeScheduleService.GetEmployeeScheduleAsync(employeeScheduleId);

            if (employeeSchedule == null)
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }
    }
}
