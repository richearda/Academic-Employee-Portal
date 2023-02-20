using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface IPersonEducationalBackgroundService
    {
        int AddPersonEducationalBackground(PersonEducationalBackground person);
        int UpdatePersonEducationalBackground(PersonEducationalBackground person);
        int DeletePersonEducationalBackground(int personEducationalBackgroundID);
        IQueryable<PersonEducationalBackground> GetPersonEducationalBackgrounds();
        Person GetPersonEducationalBackgroundById(int personEducationalBackgroundID);
        int ActivatePersonEducationalBackground(int personEducationalBackgroundID);
        int DeactivatePersonEducationalBackground(int personEducationalBackgroundID);
        bool IsPersonEducationalBackgroundExist(PersonEducationalBackground person);
    }
}
