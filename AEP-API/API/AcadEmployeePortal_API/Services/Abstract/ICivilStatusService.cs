using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface ICivilStatusService
    {
        int AddCivilStatus(CivilStatus civilStatus);
        int UpdateCivilStatus(CivilStatus civilStatus);
        int DeleteCivilStatus(int civilStatusID);
        IQueryable<CivilStatus> GetCivilStatuss();
        CivilStatus GetCivilStatusById(int civilStatusID);
        int ActivateCivilStatus(int civilStatusID);
        int DeactivateCivilStatus(int civilStatusID);
        bool IsCivilStatusExist(CivilStatus civilStatus);
    }
}
