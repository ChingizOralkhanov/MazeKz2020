using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Repository;
using WebMaze.Models.Hotel;

namespace WebMaze.Controllers.Hotel
{
    public class HotelController : Controller
    {
        private CitizenUserRepository citizenUserRepository;
        private HotelRepository hotelRepository;
        private IMapper mapper;

        public HotelController(CitizenUserRepository citizenUserRepository, HotelRepository hotelRepository, IMapper mapper)
        {
            this.citizenUserRepository = citizenUserRepository;
            this.hotelRepository = hotelRepository;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var hotels = hotelRepository.GetAll();
            var hoteViewModels = mapper.Map<List<HotelViewModel>>(hotels);
            return View(hoteViewModels);
        }
    }
}
