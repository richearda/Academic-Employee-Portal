using ISMS_API.Helpers;
using ISMS_API.Models;
using ISMS_API.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EventController : Controller
    {
        private IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }
        [HttpPost(Routes.Add)]
        public int AddEvent([FromBody] Event eventName)
        {
           return  _eventService.AddEvent(eventName);
        }
        [HttpPut(Routes.Edit)]
        public int UpdateEvent([FromBody] Event eventName)
        {
            return _eventService.UpdateEvent(eventName);
        }
        [HttpDelete(Routes.Delete)]
        public int DeleteEvent(int id)
        {
            return _eventService.DeleteEvent(id);
        }
        [HttpGet(Routes.Get)]
        public Event GetEvent(int eventId)
        {
            return _eventService.GetEvent(eventId);
        }
        [HttpGet(Routes.GetList)]
        public List<Event> GetEvents()
        {
            return _eventService.GetEvents();
        }
    }
}
