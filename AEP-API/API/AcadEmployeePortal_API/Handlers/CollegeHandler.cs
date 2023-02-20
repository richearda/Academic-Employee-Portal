using ISMS_API.Models;
using ISMS_API.Services.Abstract;

namespace ISMS_API.Handlers
{
    public class CollegeHandler
    {
        private ICollegeService _collegeService;

        public CollegeHandler(ICollegeService collegeService)
        {
            _collegeService = collegeService;
        }

        public ValidationResult CanAddCollege(College college)
        {
            ValidationResult result = null;

            if (college.CollegeName != null && college.CollegeName != "")
            {
                if (college.CollegeCode != null && college.CollegeCode != "")
                {
                    if (_collegeService.IsCollegeExist(college))
                        result = new ValidationResult("CollegeName", "Already existing", 400);
                }
                else
                    result = new ValidationResult("CollegeCode", "Required", 400);
            }
            else
                result = new ValidationResult("CollegeName", "Required", 400);

            return result;
        }

        public ValidationResult CanUpdateCollege(College college)
        {
            ValidationResult result = null;
            College origCollege = _collegeService.GetCollege(college.CollegeID);

            if (origCollege != null)
            {
                if (college.CollegeName == null || college.CollegeName == "")
                    result = new ValidationResult("CollegeName", "Required", 400);
                else if (college.CollegeCode == null || college.CollegeCode == "")
                    result = new ValidationResult("CollegeCode", "Required", 400);
                else if ((college.CollegeName.Equals(origCollege.CollegeName)))
                {
                    if (_collegeService.IsCollegeExist(college))
                        result = new ValidationResult("CollegeName", "Already existing", 400);
                }
            }
            else
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }

        public ValidationResult CanCheckCollege(int ID)
        {
            ValidationResult result = null;
            College college = _collegeService.GetCollege(ID);

            if (college == null)
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }
    }
}