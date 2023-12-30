using Hotel.Application.DTOs.AdminSide.Product;
using Hotel.Application.DTOs.SiteSide.UserRegister;
using Hotel.Domain.Entities.Account;
using Hotel.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore.Update;

namespace Hotel.Application.Services.Interface;

public interface IHotelService
{
    public IEnumerable<Domain.Entities.Product.Hotel> GetAllHotel();
    public void CreateHotel(CreateHotelDTO model);
    public void UpdateHotel(EditHotelDTO hotel);
    public EditHotelDTO GetHotelById(int id);
    bool IsExistByNatinalCode(string natinalCode);
    public void AddUser(User user);
    User FillUser(UserRegisterDTO userDTO);
    bool RegisterUser(UserRegisterDTO userRegisterDto);
    User? GetUserByNationalCode(string nationalCode);

    bool CheckPassword (string nationalCode,string Password);
}