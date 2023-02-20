using ISMS_API.DTOs;
using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface IDeanService
    {
        int AddDean(Dean deanDto);
        int UpdateDean(Dean dean);
        int DeleteDean(int deanId);
        ICollection<DeanDto> GetDeans();
        
        //DeanDto GetDeanById(int DeanId);
        Dean GetDeanByPersonId(int personId);
        //int ActivateDean(int DeanId);
        //int DeactivateDean(int DeanId);
        //bool IsDeanExist(Dean Dean);


    }
}
