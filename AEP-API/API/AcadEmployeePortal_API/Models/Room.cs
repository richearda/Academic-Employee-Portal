using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class Room
    {

        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string RoomCode { get; set; }
        public int? RoomTypeId { get; set; }
        public int? Capacity { get; set; }
        public bool? IsActive { get; set; }

        public virtual RoomType RoomType { get; set; }
        //public virtual ICollection<Schedule> Schedules { get; set; }


    }
}
