using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Hotel.Application.DTOs.AdminSide.Product;
using Hotel.Application.DTOs.SiteSide.UserLogin;
using Hotel.Application.DTOs.SiteSide.UserRegister;
using Hotel.Application.Security;
using Hotel.Application.Services.Interface;
using Hotel.Domain.Entities.Account;
using Hotel.Domain.Entities.Product;
using Hotel.Domain.RepositoryInterface;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Hotel = Hotel.Domain.Entities.Product.Hotel;

namespace Hotel.Application.Services.Implement
{
    public class HotelService : IHotelService
    {
        #region Ctor

        private readonly INotyfService _notyf;
        private readonly IHotelRepository _ServiceRepo;
       

        public HotelService(INotyfService notyf, IHotelRepository service)
        {
            _notyf = notyf;
            _ServiceRepo = service;
        }

        #endregion

        public IEnumerable<Domain.Entities.Product.Hotel> GetAllHotel()
        {
            return _ServiceRepo.GetAllHotel();
        }

        public void CreateHotel(CreateHotelDTO model)
        {
            var hotel = new Domain.Entities.Product.Hotel()
            {
                Title = model.Title,
                Description = model.Description,
                RoomCount = model.RoomCount,
                StageCount = model.StageCount,
                EntryTime = model.EntryTime,
                ExitTime = model.ExitTime,
                DateTime = DateTime.Now,
                Address = model.Address,
                City = model.City,
                State = model.State,
            };
            _ServiceRepo.CreateHotel(hotel);
        }

        public void UpdateHotel(EditHotelDTO hotel)
        {
            var hotell = new Domain.Entities.Product.Hotel()
            {
                Title = hotel.Title,
                Description = hotel.Description,
                RoomCount = hotel.RoomCount,
                StageCount = hotel.StageCount,
                EntryTime = hotel.EntryTime,
                ExitTime = hotel.ExitTime,
                Address = hotel.Address,
                City = hotel.City,
                State = hotel.State,
            };
            _ServiceRepo.UpdateHotel(hotell);
        }

        public EditHotelDTO GetHotelById(int id)
        {
            var hotel = _ServiceRepo.GetHotelById(id);
            var hotelDTO = new EditHotelDTO()
            {
                Title = hotel.Title,
                Description = hotel.Description,
                RoomCount = hotel.RoomCount,
                StageCount = hotel.StageCount,
                EntryTime = hotel.EntryTime,
                ExitTime = hotel.ExitTime,
                Address = hotel.Address,
                City = hotel.City,
                State = hotel.State,
            };
            return hotelDTO;
        }

    }
}
