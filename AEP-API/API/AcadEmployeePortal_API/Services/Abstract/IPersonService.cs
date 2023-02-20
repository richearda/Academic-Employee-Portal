using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface IPersonService
    {
        int AddPerson(Person person);
        int UpdatePerson(Person person);
        int DeletePerson(int personID);
        IQueryable<Person> GetPeople();
        Person GetPersonById(int personID);
        int ActivatePerson(int ID);
        int DeactivatePerson(int ID);
        bool IsPersonExist(Person person);




    }
}
