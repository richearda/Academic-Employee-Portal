using ISMS_API.Data;
using ISMS_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services
{
    public class CitizenshipService
    {
        private EmpPortalDbContext _dbContext;
        public CitizenshipService(EmpPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddCitizenship(Citizenship citizenship)
        {
            _dbContext.Citizenships.Add(citizenship);
            return _dbContext.SaveChanges();
        }

        public int UpdateCitizenship(Citizenship citizenship)
        {
            _dbContext.Entry(citizenship).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeleteCitizenship(int CitizenshipID)
        {
            Citizenship toDelete = _dbContext.Citizenships.AsNoTracking().Where(s => s.CitizenshipId == CitizenshipID).FirstOrDefault();
            _dbContext.Entry(toDelete).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }


        public Citizenship GetCitizenship(int citizenshipID)
        {
            return _dbContext.Citizenships.AsNoTracking().Where(s => s.CitizenshipId == citizenshipID).FirstOrDefault();
        }

        public IQueryable<Citizenship> GetCitizenships()
        {
            return _dbContext.Citizenships.Where(s => s.IsActive == true);
        }

        public int ActivateCitizenship(int citizenshipID)
        {
            Citizenship toActivate = _dbContext.Citizenships.AsNoTracking().Where(s => s.CitizenshipId == citizenshipID).FirstOrDefault();
            toActivate.IsActive = true;
            _dbContext.Entry(toActivate).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeactivateCitizenship(int citizenshipID)
        {
            Citizenship toDeactivate = _dbContext.Citizenships.AsNoTracking().Where(s => s.CitizenshipId == citizenshipID).FirstOrDefault();
            toDeactivate.IsActive = false;
            _dbContext.Entry(toDeactivate).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public bool IsCitizenshipExist(Citizenship Citizenship)
        {
            Citizenship checkCitizenship = _dbContext.Citizenships.Where(s => s.CitizenshipId == Citizenship.CitizenshipId).FirstOrDefault();
            return (checkCitizenship != null);
        }
    }
}
