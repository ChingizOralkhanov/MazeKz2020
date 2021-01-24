using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Repository;
using WebMaze.Models.Hotel;
using WebMaze.Services;

namespace WebMaze.Controllers
{
    public class HotelController : Controller
    {
        private HotelRepository hotelRepository;
        private RoomRepository roomRepository;
        private HotelService hotelService;
        private IMapper mapper;

        public HotelController(
            HotelRepository hotelRepository,
            RoomRepository roomRepository,
            HotelService hotelService,
            IMapper mapper)
        {
            this.hotelRepository = hotelRepository;
            this.roomRepository = roomRepository;
            this.hotelService = hotelService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var viewModel = new HotelViewModel();
            return View(viewModel);
        }
    }
}
