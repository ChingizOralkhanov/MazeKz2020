using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model.Hotel;

namespace WebMaze.DbStuff.Repository
{
    public class RoomRepository : BaseRepository<Room>
    {
        public RoomRepository(WebMazeContext context) : base(context)
        {

        }

        public List<Room> GetRoomsByHotelName(string hotelName)
        {
            return dbSet.Where(x => x.HotelName == hotelName).OrderBy(x => x.Price).ToList();
        }
        public Room GetById(long roomId)
        {
            return dbSet.FirstOrDefault(x => x.Id == roomId);
        }
        public Room GetByUserId(long userId)
        {
            return dbSet.FirstOrDefault(x => x.User.Id == userId);
        }
        public void DeleteUserFromRoom(long userId)
        {
            var room = GetByUserId(userId);
            room.RoomStatus = RoomStatus.Available;
            room.IsClean = true;
            room.User = null;
            this.Save(room);
        }
    }
}
