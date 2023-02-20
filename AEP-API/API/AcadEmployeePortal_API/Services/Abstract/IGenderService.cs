using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface IGenderService
    {
        int AddGender(Gender gender);      
        int DeleteGender(int genderID);
        IQueryable<Gender> GetGenders();
        int UpdateGender(Gender gender);
        Gender GetGender(int genderID);
        int ActivateGender(int genderID);
        int DeactivateGender(int genderID);
        bool IsGenderExist(Gender gender);
    }
}
