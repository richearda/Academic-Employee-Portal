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
    
    
    public class PersonEducationalBackgroundService : IPersonEducationalBackgroundService
    {
        private EmpPortalDbContext _dbContext;
        public PersonEducationalBackgroundService(EmpPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }




        public int ActivatePersonEducationalBackground(int personEducationalBackgroundID)
        {
            PersonEducationalBackground toActivate = _dbContext.PersonEducationalBackgrounds.AsNoTracking().Where(b => b.PersonEducationalBackgroundId == personEducationalBackgroundID).FirstOrDefault();
            toActivate.IsActive = true;
            _dbContext.Entry(toActivate).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int AddPersonEducationalBackground(PersonEducationalBackground personEducationalBackground)
        {
            _dbContext.PersonEducationalBackgrounds.Add(personEducationalBackground);
            return _dbContext.SaveChanges();
        }

        public int DeactivatePersonEducationalBackground(int personEducationalBackgroundID)
        {
            PersonEducationalBackground toDeactivate = _dbContext.PersonEducationalBackgrounds.AsNoTracking().Where(b => b.PersonEducationalBackgroundId == personEducationalBackgroundID).FirstOrDefault();
            toDeactivate.IsActive = false;
            _dbContext.Entry(toDeactivate).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeletePersonEducationalBackground(int personEducationalBackgroundID)
        {
            PersonEducationalBackground toDelete = _dbContext.PersonEducationalBackgrounds.AsNoTracking().Where(b => b.PersonEducationalBackgroundId == personEducationalBackgroundID).FirstOrDefault();      
            _dbContext.Entry(toDelete).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public PersonEducationalBackground GetPersonEducationalBackgroundById(int personEducationalBackgroundID)
        {
            return _dbContext.PersonEducationalBackgrounds.AsNoTracking().Where(b => b.PersonEducationalBackgroundId == personEducationalBackgroundID).FirstOrDefault();
        }

        public IQueryable<PersonEducationalBackground> GetPersonEducationalBackgrounds()
        {
            return _dbContext.PersonEducationalBackgrounds.AsNoTracking().Where(b => b.IsActive == true);
        }

        public bool IsPersonEducationalBackgroundExist(PersonEducationalBackground personEducationalBackground)
        {
            PersonEducationalBackground isExist = _dbContext.PersonEducationalBackgrounds.Where(b => b.PersonEducationalBackgroundId == personEducationalBackground.PersonEducationalBackgroundId).FirstOrDefault();
            return (isExist != null);
        }

        public int UpdatePersonEducationalBackground(PersonEducationalBackground personEducationalBackground)
        {
            _dbContext.Entry(personEducationalBackground).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        Person IPersonEducationalBackgroundService.GetPersonEducationalBackgroundById(int personEducationalBackgroundID)
        {
            throw new NotImplementedException();
        }
    }
}
