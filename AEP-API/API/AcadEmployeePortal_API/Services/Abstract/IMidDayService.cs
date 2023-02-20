using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface IMidDayService
    {
        IQueryable<MidDay> GetMidDays();
        MidDay GetMidDayById(int midDayId);
        int ActivateMidDay(int midDayId);
        int DeactivateMidDay(int midDayId);
        bool IsMidDayExist(MidDay midDay);
    }
}
