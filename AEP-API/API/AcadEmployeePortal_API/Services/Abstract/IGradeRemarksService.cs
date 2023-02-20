using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface IGradeRemarksService
    {
        int AddGradeRemarks(GradeRemarks gradeRemarks);
        int UpdateGradeRemarks(GradeRemarks gradeRemarks);
        int DeleteGradeRemarks(int gradeRemarksId);
        IQueryable<GradeRemarks> GetGradeRemarks();
        GradeRemarks GetGradeRemarksById(int gradeRemarksId);
        int ActivateGradeRemarks(int gradeRemarksId);
        int DeactivateGradeRemarks(int gradeRemarksId);
        bool IsGradeRemarksExist(GradeRemarks gradeRemarks);
    }
}
