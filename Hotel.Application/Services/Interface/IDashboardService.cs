using Hotel.Application.DTOs.AdminSide.Product;
using Hotel.Domain.Entities.Product;

namespace Hotel.Application.Services.Interface;

public interface IDashboardService
{
    public CreateHotelDTO CreateHotel(CreateHotelDTO hotel);
    public IEnumerable<Domain.Entities.Product.Hotel> GetAllHotel();
    public Domain.Entities.Product.Hotel GetHotelById(int id);
    public EditHotelDTO EditHotelById(int id, Domain.Entities.Product.Hotel hotel, HotelAddress address);
    public void UpdateHotel(Domain.Entities.Product.Hotel hotel);
    public void UpdateAddress(HotelAddress address);
    
}