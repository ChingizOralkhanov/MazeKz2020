using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model.Hotel;
using WebMaze.Models.Hotel;

namespace WebMaze.Controllers.Hotel
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        private List<RoomViewModel> SortRooms(SortParameters sordOrder, List<RoomViewModel> rooms, bool doubleRoomsOnly, bool luxRoomsOnly, bool singleRoomsOnly)
        {
            switch (sordOrder)
            {
                case SortParameters.Asc:
                    rooms = rooms.OrderBy(x => x.Price).ToList();
                    break;
                case SortParameters.Desc:
                    rooms = rooms.OrderByDescending(x => x.Price).ToList();
                    break;
                default:
                    rooms = rooms.OrderBy(x => x.Price).ToList();
                    break;
            }
            if (luxRoomsOnly)
            {
                rooms = rooms.Where(x => x.RoomType == RoomType.Lux).ToList();
            }
            if (singleRoomsOnly)
            {
                rooms = rooms.Where(x => x.RoomType == RoomType.Single).ToList();
            }
            if (doubleRoomsOnly)
            {
                rooms = rooms.Where(x => x.RoomType == RoomType.Double).ToList();
            }
            rooms = rooms.Where(x => x.RoomStatus == RoomStatus.Available).ToList();
            return rooms;
        }
    }
}
