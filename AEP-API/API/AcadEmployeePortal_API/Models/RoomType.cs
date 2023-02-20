using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.Models
{
    public class RoomType
    {
        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
        public string RoomTypeDescription { get; set; }
        public bool? IsActive { get; set; }
      public virtual ICollection<Room> Rooms { get; set; }
    }
}
