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
    public class MidDayService : IMidDayService
    {
        private EmpPortalDbContext _dbContext;
        public MidDayService(EmpPortalDbContext dbConText)
        {
            _dbContext = dbConText;
        }
        public int ActivateMidDay(int midDayId)
        {
            MidDay activateMidDay = _dbContext.MidDay.Where(m => m.MidDayId == midDayId).FirstOrDefault();
            activateMidDay.IsActive = true;
            _dbContext.Entry(activateMidDay).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeactivateMidDay(int midDayId)
        {
            MidDay deactivateMidDay = _dbContext.MidDay.Where(m => m.MidDayId == midDayId).FirstOrDefault();
            deactivateMidDay.IsActive = false;
            _dbContext.Entry(deactivateMidDay).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public MidDay GetMidDayById(int midDayId)
        {
            return _dbContext.MidDay.AsNoTracking().Where(m => m.MidDayId == midDayId).FirstOrDefault();
        }

        public IQueryable<MidDay> GetMidDays()
        {
            return _dbContext.MidDay.Where(m => m.IsActive == true);
        }

        public bool IsMidDayExist(MidDay midDay)
        {
            MidDay midDayExist = _dbContext.MidDay.Where(m => m.MidDayId == midDay.MidDayId).FirstOrDefault();
            return (midDayExist != null);
        }
    }
}
