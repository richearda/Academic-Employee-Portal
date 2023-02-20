using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISMS_API.DTOs
{
    public class RoomDto
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string RoomCode { get; set; }
        public string RoomTypeName { get; set; }
        public string RoomTypeDescription { get; set; }
    }
}
