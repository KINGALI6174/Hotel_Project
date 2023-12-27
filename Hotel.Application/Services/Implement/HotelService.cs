using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Hotel.Application.DTOs.AdminSide.Product;
using Hotel.Application.Services.Interface;
using Hotel.Domain.Entities.Product;
using Hotel.Domain.RepositoryInterface;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Hotel.Application.Services.Implement
{
    public class HotelService : IHotelService
    {
        #region Ctor

        
        private readonly IHotelRepository _Service;

        public HotelService (INotyfService toast, IHotelRepository service)
        {
            _Service = service;
        }
        

        #endregion

        public IEnumerable<Domain.Entities.Product.Hotel> GetAllHotel()
        {
           return _Service.GetAllHotel();
        }

        public void AddHotel(Domain.Entities.Product.Hotel hotel)
        {
            _Service.AddHotel(hotel);
        }

        public void InsetAddress(HotelAddress address)
        {
            _Service.InsetAddress(address);
        }

        public void UpdateHotel(Domain.Entities.Product.Hotel hotel)
        {
            _Service.UpdateHotel(hotel);
        }

        public void UpdateAddress(HotelAddress address)
        {
            _Service.UpdateAddress(address);
        }

        public Domain.Entities.Product.Hotel GetHotelById(int id)
        {
            return _Service.GetHotelById(id);
        }

        public EditHotelDTO EditHotelById(int id, Domain.Entities.Product.Hotel hotel, HotelAddress address)
        {
            hotel = _Service.GetHotelById(id);
            address = _Service.GetHotelAddress(id);
            var edithoteldto = new EditHotelDTO()
            {
                ID = hotel.ID,
                Title = hotel.Title,
                Description = hotel.Description,
                EntryTime = hotel.EntryTime,
                ExitTime = hotel.ExitTime,
                IsActive = hotel.IsActive,
                RoomCount = hotel.RoomCount,
                StageCount = hotel.StageCount,
                Address = address.Address,
                City = address.City,
                State = address.State,
            };
            return edithoteldto;
        }

    }
}
