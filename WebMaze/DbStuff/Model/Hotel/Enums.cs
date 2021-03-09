using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model.Hotel
{
    public enum RoomStatus
    {
        Available = 1,
        Booked = 2,
        Occupied = 3,
        IsCleaned = 4
    }
    public enum RoomType
    {
        Single = 1,
        Double = 2,
        Lux = 3
    }
}
