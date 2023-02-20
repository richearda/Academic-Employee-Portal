using ISMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Services.Abstract
{
    public interface IEventService
    {
        List<Event> GetEvents();
        int AddEvent(Event eventName);
        int UpdateEvent(Event eventName);
        //int ActivateEvent(int eventId);
        //int DeactivateEvent(int eventId);
        int DeleteEvent(int eventId);
        bool IsEventExist(Event eventName);
        Event GetEvent(int eventId);
    }
}
