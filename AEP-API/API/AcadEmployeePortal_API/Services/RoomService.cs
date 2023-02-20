using ISMS_API.Data;
using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services
{
    public class RoomService : IRoomService
    {
        private EmpPortalDbContext _dbContext;
        public RoomService(EmpPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int ActivateRoom(int roomId)
        {
            Room activateRoom = _dbContext.Rooms.Where(r => r.RoomId == roomId).FirstOrDefault();
            activateRoom.IsActive = true;
            _dbContext.Entry(activateRoom).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int AddRoom(Room room)
        {
            _dbContext.Rooms.Add(room);
            return _dbContext.SaveChanges();
        }

        public int DeactivateRoom(int roomId)
        {
            Room deactivateRoom = _dbContext.Rooms.Where(r => r.RoomId == roomId).FirstOrDefault();
            deactivateRoom.IsActive = false;
            _dbContext.Entry(deactivateRoom).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeleteRoom(int roomId)
        {
            Room deleteRoom = _dbContext.Rooms.Where(r => r.RoomId == roomId).FirstOrDefault();
            _dbContext.Entry(deleteRoom).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public Room GetRoomById(int roomId)
        {
            return _dbContext.Rooms.AsNoTracking().Where(r => r.RoomId == roomId).FirstOrDefault();
        }

        public IQueryable<Room> GetRooms()
        {
            return _dbContext.Rooms.Where(r => r.IsActive == true);
        }

        public bool IsRoomExist(Room room)
        {
            Room roomExist = _dbContext.Rooms.Where(r => r.RoomId == room.RoomId).FirstOrDefault();       
            return (roomExist != null);
        }

        public int UpdateRoom(Room room)
        {
            _dbContext.Entry(room).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }
    }
}
