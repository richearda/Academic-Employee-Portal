using ISMS_API.Data;
using ISMS_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services
{
    public class CivilStatusService
    {
        private EmpPortalDbContext _dbContext;
        public CivilStatusService(EmpPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddCivilStatus(CivilStatus civilStatus)
        {
            _dbContext.CivilStatus.Add(civilStatus);
            return _dbContext.SaveChanges();
        }

        public int UpdateCivilStatus(CivilStatus civilStatus)
        {
            _dbContext.Entry(civilStatus).State = EntityState.Modified;
            return _dbContext.SaveChanges();       
        }

        public int DeleteCivilStatus(int civilStatusID)
        {
            CivilStatus toDelete = _dbContext.CivilStatus.AsNoTracking().Where(s => s.CivilStatusId == civilStatusID).FirstOrDefault();
            _dbContext.Entry(toDelete).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }


        public CivilStatus GetCivilStatus(int civilStatusID)
        {
            return _dbContext.CivilStatus.AsNoTracking().Where(s => s.CivilStatusId == civilStatusID).FirstOrDefault();
        }

        public IQueryable<CivilStatus> GetCivilStatuss()
        {
            return _dbContext.CivilStatus.Where(s => s.IsActive == true);
        }

        public int ActivateCivilStatus(int CivilStatusID)
        {
            CivilStatus toActivate = _dbContext.CivilStatus.AsNoTracking().Where(s => s.CivilStatusId == CivilStatusID).FirstOrDefault();
            toActivate.IsActive = true;
            _dbContext.Entry(toActivate).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeactivateCivilStatus(int civilStatusID)
        {
            CivilStatus toDeactivate = _dbContext.CivilStatus.AsNoTracking().Where(s => s.CivilStatusId == civilStatusID).FirstOrDefault();
            toDeactivate.IsActive = false;
            _dbContext.Entry(toDeactivate).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public bool IsCivilStatusExist(CivilStatus CivilStatus)
        {
            CivilStatus checkCivilStatus = _dbContext.CivilStatus.Where(s => s.CivilStatusId == CivilStatus.CivilStatusId).FirstOrDefault();
            return (checkCivilStatus != null);
        }
    }
}
