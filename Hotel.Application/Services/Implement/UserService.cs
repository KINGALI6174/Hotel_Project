using Hotel.Application.DTOs.AdminSide.User;
using Hotel.Application.DTOs.SiteSide.UserLogin;
using Hotel.Application.DTOs.SiteSide.UserRegister;
using Hotel.Application.Security;
using Hotel.Application.Services.Interface;
using Hotel.Domain.Entities.Account;
using Hotel.Domain.RepositoryInterface;

namespace Hotel.Application.Services.Implement;

public class UserService : IUserService
{
    #region Ctor

    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    #endregion

    public bool IsExistByNatinalCode(string natinalCode)
    {
        return _userRepository.IsExistByNatinalCode(natinalCode.Trim());
    }

    public void AddUser(User user)
    {
        _userRepository.AddUserToDataBase(user);
    }

    public User FillUser(UserRegisterDTO userDTO)
    {
        Domain.Entities.Account.User user = new User()
        {
            FName = userDTO.FName,
            LName = userDTO.LName,
            NationalCode = userDTO.NationalCode,
            PhoneNumber = userDTO.PhoneNumber,
            Email = userDTO.Email.Trim(),
            CreateDate = DateTime.Now,
            Password = PasswordHelper.EncodePasswordMd5(userDTO.Password),
        };
        return user;
    }

    public bool RegisterUser(UserRegisterDTO userRegisterDto)
    {
        // Is Exist User By National Code
        var isExist = IsExistByNatinalCode(userRegisterDto.NationalCode);
        if (isExist == true)
        {
            return false;
        }

        // Fill Entity
        var user = FillUser(userRegisterDto);

        // Add To Database
        AddUser(user);
        return true;
    }

    public User? GetUserByNationalCode(string nationalCode)
    {
        return _userRepository.GetUserByNationalCode(nationalCode.Trim());
    }

    public bool CheckPassword(string NationalCode, string Password)
    {
        return _userRepository.CheckPassword(NationalCode, PasswordHelper.EncodePasswordMd5(Password));
    }

    public bool LoginUser(UserLoginDTO userLoginDTO)
    {
        var user = _userRepository.GetUserByNationalCode(userLoginDTO.NationalCode);
        if (user == null)
        {
            return false;
        }

        return true;
    }

    #region Admid Side Methods

    public List<ListOfUserDTO> ListOfUsers()
    {
        List<ListOfUserDTO> ReturnModel = new List<ListOfUserDTO>();
        foreach (var item in _userRepository.ListOfUsers())
        {
            ListOfUserDTO chailmodel = new ListOfUserDTO()
            {
                CreateDate = item.CreateDate,
                LName = item.LName,
                PhoneNumber = item.PhoneNumber,
                NationalCode = item.NationalCode,
                Email = item.Email,
                UserAvatar = item.UserAvatar,
            };
            ReturnModel.Add(chailmodel);
        }
        return ReturnModel;
    }

    #endregion
}