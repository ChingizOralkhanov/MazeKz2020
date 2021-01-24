using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model.Hotel;

namespace WebMaze.DbStuff.Repository
{
    public class RoomRepository : BaseRepository<Hotel>
    {
        public RoomRepository(WebMazeContext context) : base(context)
        {

        }

    }
}
