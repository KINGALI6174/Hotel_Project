using Hotel.Application.DTOs.AdminSide.Product;
using Hotel.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore.Update;

namespace Hotel.Application.Services.Interface;

public interface IHotelService
{
    public IEnumerable<Domain.Entities.Product.Hotel> GetAllHotel();
    public void AddHotel(Domain.Entities.Product.Hotel hotel);
    public void InsetAddress(HotelAddress address);
    public void UpdateHotel(Domain.Entities.Product.Hotel hotel);
    public void UpdateAddress(HotelAddress address);
    public Domain.Entities.Product.Hotel GetHotelById(int id);

    public EditHotelDTO EditHotelById(int id,Domain.Entities.Product.Hotel hotel,HotelAddress address);
}