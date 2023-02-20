using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Handlers
{
    public class GenderHandler
    {
        private IGenderService _genderService;

        public GenderHandler(IGenderService genderService)
        {
            _genderService = genderService;
        }

        public ValidationResult CanAddGender(Gender gender)
        {
            ValidationResult result = null;

            if (gender.GenderName != null && gender.GenderName != "")
            {             
                    if (_genderService.IsGenderExist(gender))
                        result = new ValidationResult("GenderName", "Already existing", 400);             
            }
            else
                result = new ValidationResult("Gender Name", "Required", 400);

            return result;
        }

        public ValidationResult CanUpdateGender(Gender gender)
        {
            ValidationResult result = null;
            Gender origGender = _genderService.GetGender(gender.GenderId);

            if (origGender != null)
            {
                if (gender.GenderName == null || gender.GenderName == "")
                {
                    result = new ValidationResult("Gender Name", "Required", 400);
                }               
            }
            else
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }

        public ValidationResult CanCheckGender(int ID)
        {
            ValidationResult result = null;
            Gender Gender = _genderService.GetGender(ID);

            if (Gender == null)
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }
    }
}
