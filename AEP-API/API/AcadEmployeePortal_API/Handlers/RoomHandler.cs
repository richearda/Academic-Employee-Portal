using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Handlers
{
    public class RoomHandler
    {
        private IRoomService _roomService;

        public RoomHandler(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public ValidationResult CanAddRoom(Room room)
        {
            ValidationResult result = null;

            if (room.RoomName != null && room.RoomName != "")
            {
                if (room.RoomCode != null && room.RoomCode != "")
                {
                    if (_roomService.IsRoomExist(room))
                        result = new ValidationResult("Room", "Already existing", 400);
                }
                else
                    result = new ValidationResult("Room code can not be empty", "Required", 400);
            }
            else
                result = new ValidationResult("Room name can not be empty", "Required", 400);

            return result;
        }

        public ValidationResult CanUpdateRoom(Room room)
        {
            ValidationResult result = null;
            Room origRoom = _roomService.GetRoomById(room.RoomId);

            if (origRoom != null)
            {
                if (room.RoomName == null || room.RoomName == "")
                    result = new ValidationResult("Room name can not be empty", "Required", 400);
                else if (room.RoomCode == null || room.RoomCode == "")
                    result = new ValidationResult("Room code can not be empty", "Required", 400);
                else if(room.RoomName.Equals(origRoom.RoomName) && room.RoomCode.Equals(origRoom.RoomCode))
                {
                    if (_roomService.IsRoomExist(room))
                        result = new ValidationResult("The room is existing", "Already existing", 400);
                }
            }
            else
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }

        public ValidationResult CanCheckRoom(int roomId)
        {
            ValidationResult result = null;
            Room Room = _roomService.GetRoomById(roomId);

            if (Room == null)
                result = new ValidationResult("Error", "Does not exist", 404);

            return result;
        }
    }
}
