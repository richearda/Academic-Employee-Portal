using ISMS_API.Data;
using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ISMS_API.Services
{
    public class CollegeService : ICollegeService
    {
        private EmpPortalDbContext _dBcontext;

        public CollegeService(EmpPortalDbContext dbcontext)
        {
            _dBcontext = dbcontext;
        }

        public int AddCollege(College college)
        {
            _dBcontext.Colleges.Add(college);
            return _dBcontext.SaveChanges();
        }

        public int DeactivateCollege(int ID)
        {
            College toDeactivate = _dBcontext.Colleges.AsNoTracking().Where(c => c.CollegeID == ID).FirstOrDefault();
            //update IsActive
            toDeactivate.IsActive = false;
            _dBcontext.Entry(toDeactivate).State = EntityState.Modified;
            return _dBcontext.SaveChanges();
        }

        public int ActivateCollege(int ID)
        {
            College toActivate = _dBcontext.Colleges.AsNoTracking().Where(c => c.CollegeID == ID).FirstOrDefault();
            //update IsActive
            toActivate.IsActive = true;
            _dBcontext.Entry(toActivate).State = EntityState.Modified;
            return _dBcontext.SaveChanges();
        }

        public int DeleteCollege(int ID)
        {
            College toDelete = _dBcontext.Colleges.AsNoTracking().Where(c => c.CollegeID == ID).FirstOrDefault();          
            _dBcontext.Entry(toDelete).State = EntityState.Deleted;
            return _dBcontext.SaveChanges();
        }

        public College GetCollege(int ID)
        {
            return _dBcontext.Colleges.AsNoTracking().Where(c => c.CollegeID == ID).FirstOrDefault();
        }

        public IQueryable<College> GetColleges()
        {
            return _dBcontext.Colleges.Where(c => c.IsActive == true);
        }

        public bool IsCollegeExist(College college)
        {
            College toCheck = _dBcontext.Colleges.Where(c => c.CollegeName == college.CollegeName).FirstOrDefault();
            return (toCheck != null);
        }

        public int UpdateCollege(College college)
        {
            _dBcontext.Entry(college).State = EntityState.Modified;
            return _dBcontext.SaveChanges();
        }
        public List<CollegeDepartment> GetCollegeDepartments(string collegeName)
        {
            return _dBcontext.CollegeDepartments.Include(cs => cs.Department).Where(cd => cd.College.CollegeName == collegeName).ToList();
        }
    }
}