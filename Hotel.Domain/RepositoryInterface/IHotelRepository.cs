
using Hotel.Domain.Entities.Account;
using Hotel.Domain.Entities.Product;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Domain.RepositoryInterface;


public interface IHotelRepository
{
    public IEnumerable<Entities.Product.Hotel> GetAllHotel();
    public void CreateHotel(Entities.Product.Hotel hotel);
    public void UpdateHotel(Entities.Product.Hotel hotel);
    public Entities.Product.Hotel GetHotelById(int id);

}