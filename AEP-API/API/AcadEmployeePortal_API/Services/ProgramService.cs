using ISMS_API.Data;
using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services
{
    public class ProgramService : IProgramService
    {
        private EmpPortalDbContext _dbContext;
        public ProgramService(EmpPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int ActivateProgram(int programId)
        {
            Programs activateProgram = _dbContext.Programs.AsNoTracking().Where(p => p.ProgramID == programId).FirstOrDefault();
            activateProgram.IsActive = true;
            _dbContext.Entry(activateProgram).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int AddProgram(Programs program)
        {
            _dbContext.Programs.Add(program);
            return _dbContext.SaveChanges();
        }

        public int DeactivateProgram(int programId)
        {
            Programs deactivateProgram = _dbContext.Programs.AsNoTracking().Where(p => p.ProgramID == programId).FirstOrDefault();
            deactivateProgram.IsActive = false;
            _dbContext.Entry(deactivateProgram).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeleteProgram(int programID)
        {
            Programs deleteProgram = _dbContext.Programs.AsNoTracking().Where(p => p.ProgramID == programID).FirstOrDefault();
            _dbContext.Entry(deleteProgram).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public Programs GetProgram(int programID)
        {
            return _dbContext.Programs.AsNoTracking().Where(p => p.ProgramID == programID).FirstOrDefault();
        }

        public IQueryable<Programs> GetPrograms()
        {
            return _dbContext.Programs.Where(p => p.IsActive == true);
        }

        public bool IsProgramExist(Programs program)
        {
            Programs checkProgram = _dbContext.Programs.Where(p => p.ProgramID == program.ProgramID).FirstOrDefault();       
            return (checkProgram != null);
        }

        public int UpdateProgram(Programs program)
        {
            _dbContext.Entry(program).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        //public Major GetProgramMajors()
        //{
        //    Major majors = _dbContext.ProgramMajors.Include(p => p.Major).OrderBy(p => p.Program);
        //    return majors;
        //}
    }
}
