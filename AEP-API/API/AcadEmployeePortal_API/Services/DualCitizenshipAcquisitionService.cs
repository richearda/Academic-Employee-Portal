using ISMS_API.Data;
using ISMS_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services
{
    public class DualDualCitizenshipAcquisitionAcquisitionService
    {
        private EmpPortalDbContext _dbContext;
        public DualDualCitizenshipAcquisitionAcquisitionService(EmpPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddDualCitizenshipAcquisition(DualCitizenshipAcquisition dualCitizenshipAcquisition)
        {
            _dbContext.DualCitizenshipAcquisitions.Add(dualCitizenshipAcquisition);
            return _dbContext.SaveChanges();
        }

        public int UpdateDualCitizenshipAcquisition(DualCitizenshipAcquisition dualCitizenshipAcquisition)
        {
            _dbContext.Entry(dualCitizenshipAcquisition).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeleteDualCitizenshipAcquisition(int dualCitizenshipAcquisitionID)
        {
            DualCitizenshipAcquisition toDelete = _dbContext.DualCitizenshipAcquisitions.AsNoTracking().Where(s => s.DualCitizenshipAcquisitionId == dualCitizenshipAcquisitionID).FirstOrDefault();
            _dbContext.Entry(toDelete).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }


        public DualCitizenshipAcquisition GetDualCitizenshipAcquisition(int dualCitizenshipAcquisitionID)
        {
            return _dbContext.DualCitizenshipAcquisitions.AsNoTracking().Where(s => s.DualCitizenshipAcquisitionId == dualCitizenshipAcquisitionID).FirstOrDefault();
        }

        public IQueryable<DualCitizenshipAcquisition> GetDualCitizenshipAcquisitions()
        {
            return _dbContext.DualCitizenshipAcquisitions.Where(s => s.IsActive == true);
        }

        public int ActivateDualCitizenshipAcquisition(int dualCitizenshipAcquisitionID)
        {
            DualCitizenshipAcquisition toActivate = _dbContext.DualCitizenshipAcquisitions.AsNoTracking().Where(s => s.DualCitizenshipAcquisitionId == dualCitizenshipAcquisitionID).FirstOrDefault();
            toActivate.IsActive = true;
            _dbContext.Entry(toActivate).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeactivateDualCitizenshipAcquisition(int dualCitizenshipAcquisitionID)
        {
            DualCitizenshipAcquisition toDeactivate = _dbContext.DualCitizenshipAcquisitions.AsNoTracking().Where(s => s.DualCitizenshipAcquisitionId == dualCitizenshipAcquisitionID).FirstOrDefault();
            toDeactivate.IsActive = false;
            _dbContext.Entry(toDeactivate).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public bool IsDualCitizenshipAcquisitionExist(DualCitizenshipAcquisition dualCitizenshipAcquisition)
        {
            DualCitizenshipAcquisition checkDualCitizenshipAcquisition = _dbContext.DualCitizenshipAcquisitions.Where(s => s.DualCitizenshipAcquisitionId == dualCitizenshipAcquisition.DualCitizenshipAcquisitionId).FirstOrDefault();
            return (checkDualCitizenshipAcquisition != null);
        }
    }
}
