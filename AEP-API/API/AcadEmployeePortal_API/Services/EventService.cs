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
    public class EventService : IEventService
    {
        private EmpPortalDbContext _dbContext;
        public EventService(EmpPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
      

        public int AddEvent(Event eventName)
        {
            _dbContext.Events.Add(eventName);
            return _dbContext.SaveChanges();
        }     

        public int DeleteEvent(int eventId)
        {
            Event deleteEvent = _dbContext.Events.Where(e => e.EventId == eventId).FirstOrDefault();
            _dbContext.Entry(deleteEvent).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public Event GetEvent(int eventId)
        {
            return _dbContext.Events.AsNoTracking().Where(e => e.EventId == eventId).FirstOrDefault();
        }

        public List<Event> GetEvents()
        {
            return _dbContext.Events.AsNoTracking().ToList();
        }

        public bool IsEventExist(Event eventName)
        {
            Event isExist = _dbContext.Events.Where(e => e.EventId == eventName.EventId).FirstOrDefault();
            return (isExist != null);
        }

        public int UpdateEvent(Event eventName)
        {
            _dbContext.Entry(eventName).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }
    }
}
