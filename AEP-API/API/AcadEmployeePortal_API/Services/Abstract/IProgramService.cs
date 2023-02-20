using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface IProgramService
    {
        int AddProgram(Programs program);
        int UpdateProgram(Programs program);
        int DeleteProgram(int programId);
        IQueryable<Programs> GetPrograms();
        Programs GetProgram(int programId);
        int ActivateProgram(int programId);
        int DeactivateProgram(int programId);
        bool IsProgramExist(Programs program);

    }
}
