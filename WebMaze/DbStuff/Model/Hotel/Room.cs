using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model.Hotel
{
    public class Room : BaseModel
    {
        public virtual string HotelName { get; set; }
        public virtual RoomStatus RoomStatus { get; set; }
        public virtual RoomType RoomType { get; set; }
        public virtual bool IsClean { get; set; }
        public virtual decimal Price { get; set; }
        public virtual DateTime CheckInTime { get; set; }
        public virtual DateTime CheckOutTime { get; set; }
        public virtual CitizenUser User { get; set; }
    }

}
