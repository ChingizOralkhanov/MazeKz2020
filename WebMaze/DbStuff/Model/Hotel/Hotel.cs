using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model.Hotel
{
    public class Hotel : BaseModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual List<Room> Rooms { get; set; }

    }
}
