using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface IDayService
    {
        int AddDay(Day day);
        int UpdateDay(Day day);
        int DeleteDay(int dayId);
        IQueryable<Day> GetDays();
        Day GetDayById(int dayId);
        int ActivateDay(int dayId);
        int DeactivateDay(int dayId);
        bool IsDayExist(Day day);
    }
}
