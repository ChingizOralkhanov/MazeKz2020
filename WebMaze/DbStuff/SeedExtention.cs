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
        public const string RaddisonHotelName = "Raddison";
        public const string RitzHotelName = "Ritz-Carlton";
        public const string HiltonHotelName = "Hilton";

        public static IHost Seed(this IHost host)
        {
            using(var scope = host.Services.CreateScope())
            {
                var citizenUserRepository = scope.ServiceProvider.GetService<CitizenUserRepository>();
                var hotelRepository = scope.ServiceProvider.GetService<HotelRepository>();
                var roomRepository = scope.ServiceProvider.GetService<HotelRepository>();
                if (hotelRepository == null || roomRepository == null)
                {
                    throw new Exception("Cannot Get Hotels or Rooms from ServiceProvider");
                }
                var user = citizenUserRepository.GetUserByName(AdminUserName);
                var raddisonHotel = hotelRepository.GetHotelByName(RaddisonHotelName);
                var ritzHotel = hotelRepository.GetHotelByName(RitzHotelName);
                var hiltonHotel = hotelRepository.GetHotelByName(HiltonHotelName);
                if (raddisonHotel == null)
                {
                    raddisonHotel = new Hotel
                    {
                        Name = "Raddison",
                        AvatarUrl = "/image/Hotel/Raddison/main.jpg",
                        Address = "Main Road 2",
                        Rooms = new List<Room>{
                        new Room
                        {
                            AvatarUrl = "/image/Hotel/Rooms/Single/bed.jpg",
                            HotelName = "Raddison",
                            RoomStatus = RoomStatus.Available,
                            RoomType = RoomType.Single,
                            IsClean = true,
                            Price = 100,
                            CheckInTime = null,
                            CheckOutTime = null,
                            User = null
                        },
                        new Room
                        {
                            AvatarUrl = "/image/Hotel/Rooms/Double/bed.jpg",
                            HotelName = "Raddison",
                            RoomStatus = RoomStatus.Available,
                            RoomType = RoomType.Double,
                            IsClean = true,
                            Price = 150,
                            CheckInTime = null,
                            CheckOutTime = null,
                            User = null
                        },
                        new Room
                        {
                            AvatarUrl = "/image/Hotel/Rooms/Lux/bed.jpg",
                            HotelName = "Raddison",
                            RoomStatus = RoomStatus.Available,
                            RoomType = RoomType.Lux,
                            IsClean = true,
                            Price = 250,
                            CheckInTime = null,
                            CheckOutTime = null,
                            User = null
                        }
                        }
                    };
                    hotelRepository.Save(raddisonHotel);
                }
                if (ritzHotel == null)
                {
                    ritzHotel = new Hotel
                    {
                        Name = "Ritz-Carlton",
                        AvatarUrl = "/image/Hotel/Ritz/main.jpg",
                        Address = "Main Road 1",
                        Rooms = new List<Room>{
                        new Room
                        {
                            AvatarUrl = "/image/Hotel/Rooms/Single/bed.jpg",
                            HotelName = "Ritz-Carlton",
                            RoomStatus = RoomStatus.Available,
                            RoomType = RoomType.Single,
                            IsClean = true,
                            Price = 100,
                            CheckInTime = null,
                            CheckOutTime = null,
                            User = null
                        },
                        new Room
                        {
                            AvatarUrl = "/image/Hotel/Rooms/Double/bed.jpg",
                            HotelName = "Ritz-Carlton",
                            RoomStatus = RoomStatus.Available,
                            RoomType = RoomType.Double,
                            IsClean = true,
                            Price = 150,
                            CheckInTime = null,
                            CheckOutTime = null,
                            User = null
                        },
                        new Room
                        {
                            AvatarUrl = "/image/Hotel/Rooms/Lux/bed.jpg",
                            HotelName = "Ritz-Carlton",
                            RoomStatus = RoomStatus.Available,
                            RoomType = RoomType.Lux,
                            IsClean = true,
                            Price = 250,
                            CheckInTime = null,
                            CheckOutTime = null,
                            User = null
                        }
                        }
                    };
                    hotelRepository.Save(ritzHotel);
                }
                if (hiltonHotel == null)
                {
                    hiltonHotel = new Hotel
                    {
                        Name = "Hilton",
                        AvatarUrl = "/image/Hotel/Hilton/main.jpg",
                        Address = "Main Road 3",
                        Rooms = new List<Room>{
                        new Room
                        {
                            AvatarUrl = "/image/Hotel/Rooms/Single/bed.jpg",
                            HotelName = "Hilton",
                            RoomStatus = RoomStatus.Available,
                            RoomType = RoomType.Single,
                            IsClean = true,
                            Price = 100,
                            CheckInTime = null,
                            CheckOutTime = null,
                            User = null
                        },
                        new Room
                        {
                            AvatarUrl = "/image/Hotel/Rooms/Double/bed.jpg",
                            HotelName = "Hilton",
                            RoomStatus = RoomStatus.Available,
                            RoomType = RoomType.Double,
                            IsClean = true,
                            Price = 150,
                            CheckInTime = null,
                            CheckOutTime = null,
                            User = null
                        },
                        new Room
                        {
                            AvatarUrl = "/image/Hotel/Rooms/Lux/bed.jpg",
                            HotelName = "Hilton",
                            RoomStatus = RoomStatus.Available,
                            RoomType = RoomType.Lux,
                            IsClean = true,
                            Price = 250,
                            CheckInTime = null,
                            CheckOutTime = null,
                            User = null
                        },
                        }
                    };
                    hotelRepository.Save(hiltonHotel);
                }

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
    }
}