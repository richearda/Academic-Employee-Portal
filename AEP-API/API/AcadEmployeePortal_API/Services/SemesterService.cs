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
    public class SemesterService:ISemesterService
    {
        private EmpPortalDbContext _dBcontext;

        public SemesterService(EmpPortalDbContext dbcontext)
        {
            _dBcontext = dbcontext;
        }

        public int AddSemester(Semester semester)
        {
            _dBcontext.Semesters.Add(semester);
            return _dBcontext.SaveChanges();
        }

        public int DeactivateSemester(int semesterId)
        {
            Semester deactivateSemester = _dBcontext.Semesters.AsNoTracking().Where(s => s.SemesterId == semesterId).FirstOrDefault();
            deactivateSemester.IsActive = false;
            _dBcontext.Entry(deactivateSemester).State = EntityState.Modified;
            return _dBcontext.SaveChanges();
        }

        public int ActivateSemester(int semesterId)
        {
            Semester activateSemester = _dBcontext.Semesters.AsNoTracking().Where(s => s.SemesterId == semesterId).FirstOrDefault();
            activateSemester.IsActive = true;
            _dBcontext.Entry(activateSemester).State = EntityState.Modified;
            return _dBcontext.SaveChanges();
        }

        public int DeleteSemester(int semesterId)
        {
            Semester toDelete = _dBcontext.Semesters.AsNoTracking().Where(c => c.SemesterId == semesterId).FirstOrDefault();
            _dBcontext.Entry(toDelete).State = EntityState.Deleted;
            return _dBcontext.SaveChanges();
        }

        public Semester GetSemesterById(int ID)
        {
            return _dBcontext.Semesters.AsNoTracking().Where(c => c.SemesterId == ID).FirstOrDefault();
        }

        public IQueryable<Semester> GetSemesters()
        {
            return _dBcontext.Semesters.Where(c => c.IsActive == true);
        }

        public bool IsSemesterExist(Semester semester)
        {
            Semester toCheck = _dBcontext.Semesters.Where(c => c.SemesterName == semester.SemesterName).FirstOrDefault();
            return (toCheck != null);
        }

        public int UpdateSemester(Semester semester)
        {
            _dBcontext.Entry(semester).State = EntityState.Modified;
            return _dBcontext.SaveChanges();
        }
    }

}
