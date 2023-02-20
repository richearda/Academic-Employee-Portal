using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface ICitizenshipService
    {
        int AddCitizenship(Citizenship citizenship);
        int UpdateCitizenship(Citizenship citizenship);
        int DeleteCitizenship(int citizenshipID);
        IQueryable<Citizenship> GetCitizenships();
        Citizenship GetCitizenship(int citizenshipID);
        int ActivateCitizenship(int citizenshipID);
        int DeactivateCitizenship(int citizenshipID);
        bool IsCitizenshipExist(Citizenship citizenship);
    }
}
