using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.Hotel
{
    public class HotelViewModel
    {
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
        public string Address { get; set; }
        public List<RoomViewModel> Rooms { get; set; }
    }
}
