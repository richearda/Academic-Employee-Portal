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
    public class RoomTypeService:IRoomTypeService
    {
        private EmpPortalDbContext _dbContext;
        public RoomTypeService(EmpPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int ActivateRoomType(int roomTypeId)
        {
            RoomType activateType = _dbContext.RoomTypes.AsNoTracking().Where(r => r.RoomTypeId == roomTypeId).FirstOrDefault();
            activateType.IsActive = true;
            _dbContext.Entry(activateType).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int AddRoomType(RoomType roomType)
        {
            _dbContext.RoomTypes.Add(roomType);
            return _dbContext.SaveChanges();
        }

        public int DeactivateRoomType(int roomTypeId)
        {
            RoomType deactivateType = _dbContext.RoomTypes.AsNoTracking().Where(r => r.RoomTypeId == roomTypeId).FirstOrDefault();
            deactivateType.IsActive = false;
            _dbContext.Entry(deactivateType).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeleteRoomType(int roomTypeId)
        {
            RoomType deleteType = _dbContext.RoomTypes.AsNoTracking().Where(r => r.RoomTypeId == roomTypeId).FirstOrDefault();
            _dbContext.Entry(deleteType).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public RoomType GetRoomTypeById(int roomTypeId)
        {
            return _dbContext.RoomTypes.AsNoTracking().Where(r => r.RoomTypeId == roomTypeId).FirstOrDefault();
        }

        public IQueryable<RoomType> GetRoomTypes()
        {
            return _dbContext.RoomTypes.Where(r => r.IsActive == true);
        }

        public bool IsRoomTypeExist(RoomType roomType)
        {
            RoomType checkType = _dbContext.RoomTypes.Where(r => r.RoomTypeId == roomType.RoomTypeId).FirstOrDefault();           
            return (checkType != null);
        }

        public int UpdateRoomType(RoomType roomType)
        {
            _dbContext.Entry(roomType).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }
    }
   
   
}
