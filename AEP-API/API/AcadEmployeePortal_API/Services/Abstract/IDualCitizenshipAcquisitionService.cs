using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface IDualCitizenshipAcquisitionService
    {
        int AddDualCitizenshipAcquisition(DualCitizenshipAcquisition dualCitizenshipAcquisition);
        int UpdateDualCitizenshipAcquisition(DualCitizenshipAcquisition dualCitizenshipAcquisition);
        int DeleteDualCitizenshipAcquisition(int dualCitizenshipAcquisitionID);
        IQueryable<DualCitizenshipAcquisition> GetDualCitizenshipAcquisitions();
        DualCitizenshipAcquisition GetDualCitizenshipAcquisitionById(int dualCitizenshipAcquisitionID);
        int ActivateDualCitizenshipAcquisition(int dualCitizenshipAcquisitionID);
        int DeactivateDualCitizenshipAcquisition(int dualCitizenshipAcquisitionID);
        bool IsDualCitizenshipAcquisitionExist(DualCitizenshipAcquisition dualCitizenshipAcquisition);
    }
}
