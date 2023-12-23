using Hotel.Domain.Entities.Product;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Domain.RepositoryInterface;


public interface IHotelRepository
{
    public IEnumerable<Entities.Product.Hotel> GetAllHotel();

    public void AddHotel(Entities.Product.Hotel hotel);
     public void InsetAddress(HotelAddress address);
     public void UpdateHotel(Entities.Product.Hotel hotel);
     public void UpdateAddress(HotelAddress address);
     
     public Entities.Product.Hotel GetHotelById(int id);
     

}