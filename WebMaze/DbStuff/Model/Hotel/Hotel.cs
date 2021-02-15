using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model.Hotel
{
    public class Hotel : BaseModel
    {
        public virtual string Name { get; set; }
        public virtual string AvatarUrl { get; set; }
        public virtual string Address { get; set; }
        public virtual List<Room> Rooms { get; set; }
    }
}
