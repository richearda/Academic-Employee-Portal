using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Handlers
{
    public class RoomTypeHandler
    {
        private IRoomTypeService _roomTypeService;

        public RoomTypeHandler(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        public ValidationResult CanAddRoomType(RoomType roomType)
        {
            ValidationResult result = null;

            if (roomType.RoomTypeName != null && roomType.RoomTypeName != "")
            {
                if (roomType.RoomTypeDescription != null && roomType.RoomTypeDescription != "")
                {
                    if (_roomTypeService.IsRoomTypeExist(roomType))
                        result = new ValidationResult("Room Type", "Already existing", 400);
                }
                else
                    result = new ValidationResult("Room type description", "Required", 400);
            }
            else
                result = new ValidationResult("Room type name", "Required", 400);

            return result;
        }

        public ValidationResult CanUpdateRoomType(RoomType roomType)
        {
            ValidationResult result = null;
            RoomType origRoomType = _roomTypeService.GetRoomTypeById(roomType.RoomTypeId);

            if (origRoomType != null)
            {
                if (roomType.RoomTypeName == null || roomType.RoomTypeName == "")
                    result = new ValidationResult("Room type name can not be empty", "Required", 400);
                else if (roomType.RoomTypeDescription == null || roomType.RoomTypeDescription == "")
                    result = new ValidationResult("Room type description can not be empty", "Required", 400);
                else if(roomType.RoomTypeName.Equals(origRoomType.RoomTypeName) && roomType.RoomTypeDescription.Equals(origRoomType.RoomTypeDescription))
                {
                    if (_roomTypeService.IsRoomTypeExist(roomType))
                        result = new ValidationResult("The room is existing", "Already existing", 400);
                }
            }
            else
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }

        public ValidationResult CanCheckRoomType(int roomTypeId)
        {
            ValidationResult result = null;
            RoomType roomType = _roomTypeService.GetRoomTypeById(roomTypeId);

            if (roomType == null)
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }
    }
}
