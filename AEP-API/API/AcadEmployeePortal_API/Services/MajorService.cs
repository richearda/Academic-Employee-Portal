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
    public class MajorService:IMajorService
    {
        private EmpPortalDbContext _dbContext;
        public MajorService(EmpPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int ActivateMajor(int ID)
        {
            Major toActivate = _dbContext.Majors.Where(m => m.MajorID == ID).FirstOrDefault();
            toActivate.IsActive = true;
            _dbContext.Entry(toActivate).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int AddMajor(Major major)
        {
            _dbContext.Majors.Add(major);
            return _dbContext.SaveChanges();
        }

        public int DeactivateMajor(int ID)
        {
            Major toDeactivate = _dbContext.Majors.Where(m => m.MajorID == ID).FirstOrDefault();
            toDeactivate.IsActive = false;
            _dbContext.Entry(toDeactivate).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeleteMajor(int ID)
        {
            Major toDelete = _dbContext.Majors.Where(m => m.MajorID == ID).FirstOrDefault();
            _dbContext.Entry(toDelete).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public Major GetMajor(int ID)
        {
            return _dbContext.Majors.AsNoTracking().Where(m => m.MajorID == ID).FirstOrDefault();
        }

        public IQueryable<Major> GetMajors()
        {
            return _dbContext.Majors.Where(m => m.IsActive == true);
        }

        public bool IsMajorExist(Major major)
        {
            Major checkMajor = _dbContext.Majors.Where(m => m.MajorID == major.MajorID).FirstOrDefault();
            return (checkMajor != null);
        }

        public int UpdateMajor(Major major)
        {
            _dbContext.Entry(major).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }
    }
}
