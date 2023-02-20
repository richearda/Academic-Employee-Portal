using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface IRoomService
    {
        int AddRoom(Room room);
        int UpdateRoom(Room room);
        int DeleteRoom(int roomId);
        IQueryable<Room> GetRooms();
        Room GetRoomById(int roomId);
        int ActivateRoom(int roomId);
        int DeactivateRoom(int roomId);
        bool IsRoomExist(Room room);
    }
}
