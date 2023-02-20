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
    public class DayService : IDayService
    {
        private EmpPortalDbContext _dbContext;
        public DayService(EmpPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int ActivateDay(int dayId)
        {
            Day activateDay = _dbContext.Days.Where(d => d.DayId == dayId).FirstOrDefault();
            activateDay.IsActive = true;
            _dbContext.Entry(activateDay).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int AddDay(Day day)
        {
            _dbContext.Days.Add(day);
            return _dbContext.SaveChanges();
        }

        public int DeactivateDay(int dayId)
        {
            Day deactivateDay = _dbContext.Days.Where(d => d.DayId == dayId).FirstOrDefault();
            deactivateDay.IsActive = false;
            _dbContext.Entry(deactivateDay).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeleteDay(int dayId)
        {
            Day deleteDay = _dbContext.Days.Where(d => d.DayId == dayId).FirstOrDefault();
            _dbContext.Entry(deleteDay).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public Day GetDayById(int dayId)
        {
            return _dbContext.Days.AsNoTracking().Where(d => d.DayId == dayId).FirstOrDefault();
        }

        public IQueryable<Day> GetDays()
        {
            return _dbContext.Days.Where(d => d.IsActive == true);
        }

        public bool IsDayExist(Day day)
        {
            Day curriculumExist = _dbContext.Days.Where(d => d.DayId ==  day.DayId).FirstOrDefault();
            return (curriculumExist != null);
        }

        public int UpdateDay(Day day)
        {
            _dbContext.Entry(day).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }
    }
}
