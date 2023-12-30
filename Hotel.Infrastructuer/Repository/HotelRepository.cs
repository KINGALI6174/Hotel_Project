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

    public bool IsExistByNatinalCode(string natinalCode)
    {
        return _context.Users.Any(u => u.NationalCode == natinalCode);
    }

    public void AddUserToDataBase(User user)
    {
        _context.Users.Add(user);
        SaveChange();
    }

    public void SaveChange()
    {
        _context.SaveChanges();
    }

    public User? GetUserByNationalCode(string nationalCode)
    {
        return _context.Users.SingleOrDefault(p=> p.IsDelete == false && p.NationalCode == nationalCode);
    }

    public bool CheckPassword(string nationalCode, string Password)
    {
        var user = GetUserByNationalCode(nationalCode);
        bool result = user.Password == Password;
        return result;
    }


    public void UpdateHotel(Domain.Entities.Product.Hotel hotel)
    {
        _context.Hotels.Update(hotel);
        SaveChange();
    }
}

