using ISMS_API.Data;
using ISMS_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface IRoomTypeService
    {
        IQueryable<RoomType> GetRoomTypes();
        int AddRoomType(RoomType roomType);
        int UpdateRoomType(RoomType roomType);
        int ActivateRoomType(int roomTypeId);
        int DeactivateRoomType(int roomTypeID);
        int DeleteRoomType(int roomTypeId);
        bool IsRoomTypeExist(RoomType roomType);
        RoomType GetRoomTypeById(int roomTypeId);
    }
}
