using AutoMapper;
using ISMS_API.Data;
using ISMS_API.DTOs;
using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services
{
    public class DeanService:IDeanService
    {
        private EmpPortalDbContext _dbContext;
        private IMapper _mapper;
        public DeanService(EmpPortalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int AddDean(Dean dean)
        {
           _dbContext.Deans.Add(dean);
           return _dbContext.SaveChanges();
        }

        public int DeleteDean(int deanId)
        {
            Dean deleteDean = _dbContext.Deans.Where(d => d.DeanID == deanId).FirstOrDefault();
            _dbContext.Entry(deleteDean).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public Dean GetDeanByPersonId(int personId)
        {
            return  _dbContext.Deans.Where(d => d.PersonID == personId)                          
                           .Include(d => d.College).FirstOrDefault();
           
        }

        public ICollection<DeanDto> GetDeans()
        {
            var deans = _dbContext.Deans.AsNoTracking()
                           .Include(d => d.Person).ThenInclude(p => p.Gender)
                           .Include(d => d.Person).ThenInclude(p => p.CivilStatus)
                           .Include(d => d.Person).ThenInclude(p => p.Citizenship)
                           .Include(d => d.College);
            return _mapper.Map<ICollection<DeanDto>>(deans);
        }

        //public DeanDto GetDeanByPersonId(int personId) {
        //    var dean = _dbContext.Deans.Where(d => d.PersonID == personId).AsNoTracking()
        //                   .Include(d => d.Person).ThenInclude(p => p.Gender)
        //                   .Include(d => d.Person).ThenInclude(p => p.CivilStatus)
        //                   .Include(d => d.Person).ThenInclude(p => p.Citizenship)
        //                   .Include(d => d.College);
        //    return _mapper.Map<DeanDto>(dean);
        //}
      
        public int UpdateDean(Dean dean)
        {
            _dbContext.Entry(dean).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }
    }
}
