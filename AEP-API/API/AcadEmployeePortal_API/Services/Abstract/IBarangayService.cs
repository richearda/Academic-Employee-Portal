using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface IBarangayService
    {
        IQueryable<Barangay> GetBarangays();
        int AddBarangay(Barangay barangay);
        int UpdateBarangay(Barangay barangay);
        int ActivateBarangay(int barangayId);
        int DeactivateBarangay(int barangayId);
        int DeleteBarangay(int barangayId);
        bool IsBarangayExist(Barangay barangay);
        Barangay GetBarangay(int barangayId);
    }
}
