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
    public class GradeRemarksService : IGradeRemarksService
    {
        private EmpPortalDbContext _dbContext;
        public GradeRemarksService(EmpPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int ActivateGradeRemarks(int gradeRemarksId)
        {
            GradeRemarks activateRemarks = _dbContext.GradeRemarks.Where(r => r.GradeRemarksID == gradeRemarksId).FirstOrDefault();
            activateRemarks.IsActive = true;
            _dbContext.Entry(activateRemarks).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int AddGradeRemarks(GradeRemarks gradeRemarks)
        {
            _dbContext.GradeRemarks.Add(gradeRemarks);
            return _dbContext.SaveChanges();
        }

        public int DeactivateGradeRemarks(int gradeRemarksId)
        {
            GradeRemarks deactivateRemarks = _dbContext.GradeRemarks.Where(r => r.GradeRemarksID == gradeRemarksId).FirstOrDefault();
            deactivateRemarks.IsActive = false;
            _dbContext.Entry(deactivateRemarks).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int DeleteGradeRemarks(int gradeRemarksId)
        {
            GradeRemarks deleteRemarks = _dbContext.GradeRemarks.Where(r => r.GradeRemarksID == gradeRemarksId).FirstOrDefault();
            _dbContext.Entry(deleteRemarks).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public IQueryable<GradeRemarks> GetGradeRemarks()
        {
            return _dbContext.GradeRemarks.Where(r => r.IsActive == true);
        }

        public GradeRemarks GetGradeRemarksById(int gradeRemarksId)
        {
            return _dbContext.GradeRemarks.AsNoTracking().Where(r => r.GradeRemarksID == gradeRemarksId).FirstOrDefault();
        }

        public bool IsGradeRemarksExist(GradeRemarks gradeRemarks)
        {
            GradeRemarks remarksExist = _dbContext.GradeRemarks.Where(r => r.GradeRemarksID == gradeRemarks.GradeRemarksID).FirstOrDefault();
            return (remarksExist != null);
        }

        public int UpdateGradeRemarks(GradeRemarks gradeRemarks)
        {
            _dbContext.Entry(gradeRemarks).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }
    }
}
