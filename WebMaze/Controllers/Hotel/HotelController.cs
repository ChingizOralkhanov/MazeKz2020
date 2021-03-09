using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.Controllers.CustomAttribute;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Model.Hotel;
using WebMaze.DbStuff.Repository;
using WebMaze.Models.Hotel;
using WebMaze.Services;

namespace WebMaze.Controllers.Hotel
{
    public class HotelController : Controller
    {
        private CitizenUserRepository citizenUserRepository;
        private HotelRepository hotelRepository;
        private RoomRepository roomRepository;
        private IMapper mapper;
        private UserService userService;
        private CitizenUser currentUser;
        public HotelController(CitizenUserRepository citizenUserRepository, HotelRepository hotelRepository, RoomRepository roomRepository, IMapper mapper, UserService userService)
        {
            this.citizenUserRepository = citizenUserRepository;
            this.hotelRepository = hotelRepository;
            this.roomRepository = roomRepository;
            this.mapper = mapper;
            this.userService = userService;
            this.currentUser = userService.GetCurrentUser();
        }

        public IActionResult Index()
        {
            var hotels = hotelRepository.GetAll();
            var hoteViewModels = mapper.Map<List<HotelViewModel>>(hotels);
            return View(hoteViewModels);
        }
        public IActionResult Rooms(string hotelName, SortParameters sortOrder, bool doubleRoomsOnly, bool luxRoomsOnly, bool singleRoomsOnly)
        {
            var rooms = mapper.Map<List<RoomViewModel>>(roomRepository.GetRoomsByHotelName(hotelName));
            rooms = SortRooms(sortOrder, rooms, doubleRoomsOnly, luxRoomsOnly, singleRoomsOnly);
            RoomsViewModel roomsViewModel = new RoomsViewModel();
            roomsViewModel.rooms.AddRange(rooms);
            return View(roomsViewModel);

        }


        [HttpGet]
        public IActionResult Booking(long roomId) 
        {
            var currentUser = userService.GetCurrentUser();
            var bookingViewModel = mapper.Map<BookingViewModel>(currentUser);
            bookingViewModel.RoomNumber = roomId;
            return View(bookingViewModel);
        }

        [HttpPost]
        public IActionResult Booking(BookingViewModel model)
        {
            if (ModelState.IsValid)
            {
                var roomToBook = roomRepository.GetById(model.RoomNumber);
                if(roomToBook.RoomStatus == RoomStatus.Available)
                {
                    roomToBook.User = userService.GetCurrentUser();
                    roomToBook.RoomStatus = RoomStatus.Booked;
                    roomToBook.CheckInTime = model.CheckInDate;
                    roomToBook.CheckOutTime = model.CheckoutDate;
                    roomRepository.Save(roomToBook);
                    return RedirectToAction("MyBookings");
                }
                return RedirectToAction("RoomIsBooked");
            }   
            else
            {
                return View(model);
            }
        }

        [Authorize]
        public IActionResult MyBookings()
        {
            var room = mapper.Map<RoomViewModel>(roomRepository.GetByUserId(currentUser.Id));
            if(room == null)
            {
                return RedirectToAction("Index");
            }
            if(room.RoomStatus == RoomStatus.Booked)
            {
                return View(room);
            }
            else
            {
                return RedirectToAction("BookingError");
            }
        }
        public IActionResult BookingError()
        {
            return View();
        }
        public IActionResult CancelBooking()
        {
            var room = roomRepository.GetByUserId(currentUser.Id);
            room.RoomStatus = RoomStatus.Available;
            room.User = null;
            roomRepository.Save(room);
            return RedirectToAction("MyBookings");
        }
        [IsAdmin]
        public IActionResult AdminIndex(string sortOrder)
        {
            ViewData["RoomStatusSort"] = String.IsNullOrEmpty(sortOrder) ? "status_avail" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            var rooms = mapper.Map<List<RoomViewModel>>(roomRepository.GetAll());
            foreach (var room in rooms)
            {
                room.TotalPrice = GetTotalPrice(room.Price, room.CheckInTime, room.CheckOutTime);
            }
            switch (sortOrder)
            {
                case "date_desc":
                    rooms = rooms.OrderByDescending(r => r.CheckInTime).ToList();
                    break;
                case "Date":
                    rooms = rooms.OrderBy(r => r.CheckInTime).ToList();
                    break;
                case "status_avail":
                    rooms = rooms.OrderByDescending(r => r.RoomStatus == RoomStatus.Available).ToList();
                    break;
                default:
                    rooms = rooms.OrderByDescending(s => s.User != null).ToList();
                    break;
            }
            var roomsViewModel = new RoomsViewModel();
            roomsViewModel.rooms.AddRange(rooms);
            return View(rooms);
        }
        public IActionResult ApproveBooking(long userId)
        {
            var room = roomRepository.GetByUserId(userId);
            room.RoomStatus = RoomStatus.Occupied;
            room.IsClean = true;
            roomRepository.Save(room);
            return RedirectToAction("AdminIndex");
        }
        public IActionResult DeleteBooking(long userId)
        {
            var room = roomRepository.GetByUserId(userId);
            room.RoomStatus = RoomStatus.Available;
            room.IsClean = true;
            room.CheckInTime = null;
            room.CheckOutTime = null;
            room.User = null;

            roomRepository.Save(room);
            return RedirectToAction("AdminIndex");
        }
        public IActionResult CleanRoom(long userId)
        {
            var room = roomRepository.GetByUserId(userId);
            room.IsClean = false;
            room.RoomStatus = RoomStatus.IsCleaned;
            roomRepository.Save(room);
            return RedirectToAction("AdminIndex");
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
        private decimal GetTotalPrice(decimal price, DateTime checkin, DateTime checkout)
        {
            TimeSpan time = checkout - checkin;
            return price * time.Days;
        }
    }

}
