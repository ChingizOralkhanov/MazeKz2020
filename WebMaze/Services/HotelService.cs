using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.Models.Hotel;

namespace WebMaze.Services
{
    public class HotelService
    {
        public (int, int) SetRoomsPriceRange(List<HotelViewModel> hotels)
        {
            foreach (var hotel in hotels)
            {
                foreach (var room in hotel.Rooms)
                {

                }
            }
            return (0, 0);
        }
    }
}
