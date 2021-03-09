using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Model.Hotel;

namespace WebMaze.Models.Hotel
{
    public class RoomViewModel
    {
        public long Id { get; set; }
        public string AvatarUrl { get; set; }
        public string HotelName { get; set; }
        public RoomStatus RoomStatus { get; set; }
        public RoomType RoomType { get; set; }
        public bool IsClean { get; set; }
        public decimal Price { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public CitizenUser User { get; set; }
        public decimal TotalPrice { get; set;}
    }

    public enum SortParameters
    {
        [Display(Name = "Ascending")]
        Asc = 1,
        [Display(Name = "Descending")]
        Desc = 2
    }

}
