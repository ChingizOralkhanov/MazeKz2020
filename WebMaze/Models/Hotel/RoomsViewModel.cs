using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.Hotel
{
    public class RoomsViewModel
    {

        public SortParameters SortParameters { get; set; }
        public bool SingleRoomsOnly { get; set; }
        public bool DoubleRoomsOnly { get; set; }
        public bool LuxRoomsOnly { get; set; }
        public List<RoomViewModel> rooms { get; set; }

        public RoomsViewModel() : base()
        {
            rooms = new List<RoomViewModel>();
            SortParameters = SortParameters.Asc;
        }
    }
}
