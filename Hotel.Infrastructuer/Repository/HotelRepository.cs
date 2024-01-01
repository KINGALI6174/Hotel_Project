using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Domain.Entities.Account;
using Hotel.Domain.Entities.Product;
using Hotel.Domain.RepositoryInterface;
using Hotel.Infrastructuer.DbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructuer.Repository;


public class HotelRepository : IHotelRepository
{
    private readonly HotelDbContext _context;

    public HotelRepository(HotelDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Domain.Entities.Product.Hotel> GetAllHotel()
    {
        return _context.Hotels.ToList();
    }

    public void CreateHotel(Domain.Entities.Product.Hotel hotel)
    {
        _context.Hotels.Add(hotel);
        _context.SaveChanges();
    }

    public Domain.Entities.Product.Hotel GetHotelById(int id)
    {
        return _context.Hotels.SingleOrDefault(a => a.ID == id) ?? throw new Exception();
    }

    public void UpdateHotel(Domain.Entities.Product.Hotel hotel)
    {
        _context.Hotels.Update(hotel);
        _context.SaveChanges();
    }
}

