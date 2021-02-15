using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model.Hotel;

namespace WebMaze.DbStuff.Repository
{
    public class HotelRepository : BaseRepository<Hotel>
    {
        public HotelRepository(WebMazeContext context) : base(context)
        {

        }

    }
}
