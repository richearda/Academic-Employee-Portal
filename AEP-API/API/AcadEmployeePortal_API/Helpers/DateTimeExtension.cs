using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Helpers
{
    public static class DateTimeExtension
    {

        public static int GetPersonAge(this DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;

            if (dateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        
        }


    }
}
