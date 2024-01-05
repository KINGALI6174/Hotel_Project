using Hotel.Application.DTOs.AdminSide.User;
using Hotel.Application.DTOs.SiteSide.UserRegister;
using Hotel.Domain.Entities.Account;

namespace Hotel.Application.Services.Interface;

public interface IUserService
{
    bool IsExistByNatinalCode(string natinalCode);
    void AddUser(User user);
    User FillUser(UserRegisterDTO userDTO);
    bool RegisterUser(UserRegisterDTO userRegisterDto);
    User? GetUserByNationalCode(string nationalCode);
    bool CheckPassword(string nationalCode, string Password);
    List<ListOfUserDTO> ListOfUsers();
}