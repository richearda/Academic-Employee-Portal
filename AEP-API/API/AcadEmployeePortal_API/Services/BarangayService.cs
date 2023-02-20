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
    public class BarangayService : IBarangayService
    {
        private EmpPortalDbContext _dbContext;
        public BarangayService(EmpPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int ActivateBarangay(int barangayId)
        {
            Barangay activateBarangay = _dbContext.Barangays.Where(b => b.BarangayId == barangayId).FirstOrDefault();
            activateBarangay.IsActive = true;
            _dbContext.Entry(activateBarangay).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int AddBarangay(Barangay barangay)
        {
            _dbContext.Barangays.Add(barangay);
            return _dbContext.SaveChanges();
        }

        public int DeactivateBarangay(int barangayId)
        {
            Barangay deactivateBarangay = _dbContext.Barangays.Where(b => b.BarangayId == barangayId).FirstOrDefault();
            deactivateBarangay.IsActive = false;
            _dbContext.Entry(deactivateBarangay).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeleteBarangay(int barangayId)
        {
            Barangay deleteBarangay = _dbContext.Barangays.Where(b => b.BarangayId == barangayId).FirstOrDefault();
            _dbContext.Entry(deleteBarangay).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public Barangay GetBarangay(int barangayId)
        {
            return _dbContext.Barangays.AsNoTracking().Where(b => b.BarangayId == barangayId).FirstOrDefault();
        }

        public IQueryable<Barangay> GetBarangays()
        {
            return _dbContext.Barangays.Where(b => b.IsActive == true);
        }

        public bool IsBarangayExist(Barangay barangay)
        {
            Barangay toCheck = _dbContext.Barangays.Where(b => b.BarangayId == barangay.BarangayId).FirstOrDefault();
            return (toCheck != null);

        }

        public int UpdateBarangay(Barangay barangay)
        {
            _dbContext.Entry(barangay).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }
    }
}
