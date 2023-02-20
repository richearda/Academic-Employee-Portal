using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Handlers
{
    public class DayHandler
    {

        private IDayService _dayService;

        public DayHandler(IDayService cayService)
        {
            _dayService = cayService;
        }

        public ValidationResult CanAddDay(Day day)
        {
            ValidationResult result = null;

            if (day.DayName != null && day.DayName != "")
            {
                if (day.DayCode != null && day.DayCode != "")
                {
                    if (_dayService.IsDayExist(day))
                        result = new ValidationResult("Day Name", "Already existing", 400);
                }
                else
                    result = new ValidationResult("Day Code", "Required", 400);
            }
            else
                result = new ValidationResult("Day Name", "Required", 400);

            return result;
        }

        public ValidationResult CanUpdateDay(Day day)
        {
            ValidationResult result = null;
            Day origDay = _dayService.GetDayById(day.DayId);

            if (origDay != null)
            {
                if (day.DayName == null || day.DayName == "")
                    result = new ValidationResult("Day Name", "Required", 400);
                else if (day.DayCode == null || day.DayCode == "")
                    result = new ValidationResult("DayCode", "Required", 400);
                else
                {
                    if (_dayService.IsDayExist(day))
                        result = new ValidationResult("DayName", "Already existing", 400);
                }
            }
            else
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }

        public ValidationResult CanCheckDay(int dayId)
        {
            ValidationResult result = null;
            Day day = _dayService.GetDayById(dayId);

            if (day == null)
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }


    }
}
