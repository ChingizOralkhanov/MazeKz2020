using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model.Hotel
{
    public class Room
    {
        public long Id { get; set; }
        public RoomType RoomType { get; set; }
        public RoomStatus RoomStatus { get; set; }
        public int Price { get; set; }
        public bool IsClean { get; set; }
    }
}
