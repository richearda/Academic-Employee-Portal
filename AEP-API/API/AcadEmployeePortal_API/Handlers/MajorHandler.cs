using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Handlers
{
    public class MajorHandler
    {
        private IMajorService _majorService;
        public MajorHandler(IMajorService majorService)
        {
            _majorService = majorService;
        }

        public ValidationResult CanAddMajor(Major major)
        {
            ValidationResult result = null;

            if (major.MajorName != null && major.MajorName != "")
            {
                if (major.MajorCode != null && major.MajorCode != "")
                {
                    if (_majorService.IsMajorExist(major))
                        result = new ValidationResult("MajorName", "Already existing", 400);
                }
                else
                    result = new ValidationResult("MajorCode", "Required", 400);
            }
            else
                result = new ValidationResult("MajorName", "Required", 400);

            return result;
        }

        public ValidationResult CanUpdateMajor(Major major)
        {
            ValidationResult result = null;
            Major origMajor = _majorService.GetMajor(major.MajorID);

            if (origMajor != null)
            {
                if (major.MajorName == null || major.MajorName == "")
                    result = new ValidationResult("MajorName", "Required", 400);
                else if (major.MajorCode == null || major.MajorCode == "")
                    result = new ValidationResult("MajorCode", "Required", 400);
                else if ((major.MajorCode.Equals(origMajor.MajorCode)))
                {
                    if (_majorService.IsMajorExist(major))
                        result = new ValidationResult("MajorName", "Already existing", 400);
                }
            }
            else
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }

        public ValidationResult CanCheckMajor(int ID)
        {
            ValidationResult result = null;
            Major Major = _majorService.GetMajor(ID);

            if (Major == null)
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }

    }
}
