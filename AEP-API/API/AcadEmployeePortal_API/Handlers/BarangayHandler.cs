using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Handlers
{
    public class BarangayHandler
    {
        private IBarangayService _barangayService;
        public BarangayHandler(IBarangayService barangayService)
        {
            _barangayService = barangayService;
        }

        //Validate if barangay does not exist or the input has value.
        
        public ValidationResult CanAddBarangay(Barangay barangay)
        {
            ValidationResult result = null;

            if (barangay.BarangayName != null || barangay.BarangayName != "")
            {
                bool isExist = _barangayService.IsBarangayExist(barangay);
                if (isExist)
                {
                    result = new ValidationResult("Barangay Name", "Already existing", 400);
                }             
            }
            else
                result = new ValidationResult("Barangay Name", "Required", 400);

            return result;
        }

        //Check if barangay can be updated
        public ValidationResult CanUpdateBarangay(Barangay barangay)
        {
            ValidationResult result = null;
            //Check if barangay exist
            Barangay updateBarangay = _barangayService.GetBarangay(barangay.BarangayId);
            
            //Execute when the barangay exist.
            if (updateBarangay != null)
            {
                //Check if barangay input has value.
                if (barangay.BarangayName == null || barangay.BarangayName == "")
                    result = new ValidationResult("Barangay Name", "Required", 400);
                //Check wether the updated value is the same as original value.
                else if ((barangay.BarangayName.Equals(updateBarangay.BarangayName, StringComparison.OrdinalIgnoreCase)))
                {              
                        result = new ValidationResult("Please provide different value.", "Cannot update with the same value.", 400);
                }
            }
            //Execute when the barangay does not exist.
            else
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }

        //Check if barangay exist.
        public ValidationResult CanCheckBarangay(int barangayId)
        {
            ValidationResult result = null;
            Barangay barangay = _barangayService.GetBarangay(barangayId);

            if (barangay == null)
                result = new ValidationResult("Error", "Does not exist", 404);
            return result;
        }



    }
}
