using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Model.Hotel;
using WebMaze.DbStuff.Repository;

namespace WebMaze.DbStuff
{
    public static class SeedExtention
    {
        public const string AdminUserName = "admin";

        public static IHost Seed(this IHost host)
        {
            using(var scope = host.Services.CreateScope())
            {
                var citizenUserRepository = scope.ServiceProvider.GetService<CitizenUserRepository>();
                var user = citizenUserRepository.GetUserByName(AdminUserName);
                if (user == null)
                {
                    user = new CitizenUser()
                    {
                        Login = AdminUserName,
                        Password = "123"
                    };

                    citizenUserRepository.Save(user);
                }


            }
            return host;
        }
        private static void AddHotels(IServiceScope scope)
        {
            var hotelRepository = scope.ServiceProvider.GetService<HotelRepository>();
            var roomRepository = scope.ServiceProvider.GetService<HotelRepository>();

            if (hotelRepository == null || roomRepository == null)
            {
                throw new Exception("Cannot Get Hotels or Rooms from ServiceProvider");
            }

            var rooms = new List<Room>
            {
                new Room
                {
                    HotelName = "",
                    RoomStatus = RoomStatus.Available,
                    RoomType = RoomType.Single,
                    IsClean = true,
                    Price = 100,
                    CheckInTime = DateTime.Now,
                    CheckOutTime = DateTime.Now,
                    User = null
                },
                new Room
                {
                    HotelName = "",
                    RoomStatus = RoomStatus.Available,
                    RoomType = RoomType.Double,
                    IsClean = true,
                    Price = 150,
                    CheckInTime = DateTime.Now,
                    CheckOutTime = DateTime.Now,
                    User = null
                },
                new Room
                {
                    HotelName = "",
                    RoomStatus = RoomStatus.Available,
                    RoomType = RoomType.Lux,
                    IsClean = true,
                    Price = 250,
                    CheckInTime = DateTime.Now,
                    CheckOutTime = DateTime.Now,
                    User = null
                },
            };
            var hotels = new List<Hotel>
            {
                new Hotel
                {
                    Name = "Ritz-Carlton",
                    AvatarUrl = "/image/Hotel/Ritz/main.jpg",
                    Address = "Main Road 1",
                    Rooms = rooms
                },

                new Hotel
                {
                    Name = "Raddison",
                    AvatarUrl = "/image/Hotel/Raddison/main.jpg",
                    Address = "Main Road 2",
                    Rooms = rooms
                },
                new Hotel
                {
                    Name = "Hilton",
                    AvatarUrl = "/image/Hotel/Hilton/main.jpg",
                    Address = "Main Road 3",
                    Rooms = rooms
                }
            };

        }
    }
}