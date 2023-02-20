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
    public class PersonService : IPersonService
    {
        private EmpPortalDbContext _dbContext;
        public PersonService(EmpPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int ActivatePerson(int personID)
        {
            Person activatePerson = _dbContext.People.Where(p => p.PersonId == personID).FirstOrDefault();
            activatePerson.IsActive = true;
            _dbContext.Entry(activatePerson).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int AddPerson(Person person)
        {
            _dbContext.People.Add(person);
            return _dbContext.SaveChanges();
        }


        public int DeactivatePerson(int personID)
        {
            Person deactivatePerson = _dbContext.People.Where(p => p.PersonId == personID).FirstOrDefault();
            deactivatePerson.IsActive = false;
            _dbContext.Entry(deactivatePerson).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeletePerson(int personID)
        {
            Person deletePerson = _dbContext.People.Where(p => p.PersonId == personID).FirstOrDefault();
            _dbContext.Entry(deletePerson).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public Person GetPersonById(int personID)
        {
            return _dbContext.People.Where(p => p.PersonId == personID).FirstOrDefault();
        }
      
        public IQueryable<Person> GetPeople()
        {
            return _dbContext.People.Where(p => p.IsActive == true);
        }

        public bool IsPersonExist(Person person)
        {
            Person isPersonExist = _dbContext.People.Where(p => p.PersonId == person.PersonId).FirstOrDefault();
            return (isPersonExist != null);

        }

        public int UpdatePerson(Person person)
        {
            _dbContext.Entry(person).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }
    }
}
