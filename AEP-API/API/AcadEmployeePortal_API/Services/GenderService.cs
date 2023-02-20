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
    public class GenderService:IGenderService
    {
        private EmpPortalDbContext _dbContext;
        public GenderService(EmpPortalDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public int AddGender(Gender gender)
        {
            _dbContext.Gender.Add(gender);
            return _dbContext.SaveChanges();
        }

        public int UpdateGender(Gender gender)
        {
            _dbContext.Entry(gender).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeleteGender(int genderID)
        {
            Gender toDelete = _dbContext.Gender.AsNoTracking().Where(s => s.GenderId == genderID).FirstOrDefault();
            _dbContext.Entry(toDelete).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }


        public Gender GetGender(int ID)
        {
            return _dbContext.Gender.AsNoTracking().Where(s => s.GenderId == ID).FirstOrDefault();
        }

        public IQueryable<Gender> GetGenders()
        {
            return _dbContext.Gender.Where(s => s.IsActive == true);
        }

        public int ActivateGender(int genderID)
        {
            Gender toActivate = _dbContext.Gender.AsNoTracking().Where(s => s.GenderId == genderID).FirstOrDefault();
            toActivate.IsActive = true;
            _dbContext.Entry(toActivate).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeactivateGender(int ID)
        {
            Gender toDeactivate = _dbContext.Gender.AsNoTracking().Where(s => s.GenderId == ID).FirstOrDefault();
            toDeactivate.IsActive = false;
            _dbContext.Entry(toDeactivate).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public bool IsGenderExist(Gender gender)
        {
            Gender checkGender = _dbContext.Gender.Where(s => s.GenderId == gender.GenderId).FirstOrDefault();       
             return (checkGender != null);       
        }




    }
}
