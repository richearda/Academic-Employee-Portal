using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface IMajorService
    {

        IQueryable<Major> GetMajors();
        int AddMajor(Major major);
        int UpdateMajor(Major major);
        int ActivateMajor(int ID);
        int DeactivateMajor(int ID);
        int DeleteMajor(int ID);
        bool IsMajorExist(Major major);
        Major GetMajor(int ID);


    }
}
