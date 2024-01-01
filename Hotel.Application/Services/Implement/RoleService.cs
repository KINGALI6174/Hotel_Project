using Hotel.Application.Services.Interface;
using Hotel.Domain.Entities.Role;
using Hotel.Domain.RepositoryInterface;
using Hotel.Infrastructuer.Repository;
using System.Data;

namespace Hotel.Application.Services.Implement;

public class RoleService : IRoleService
{
    #region Ctor

    private readonly IRoleRepository _roleRepository;
    private readonly IUserRepository _userRepository;

    public RoleService(IRoleRepository roleRepository, IUserRepository userRepository)
    {
        _roleRepository = roleRepository;
        _userRepository = userRepository;
    }


    #endregion

    public List<Role> GetUserRoleByUserId(int userId)
    {
        return _roleRepository.GetUserRoleByUserId(userId);
    }

    public bool IsUserAdmin(int UserId)
    {
        var user = _userRepository.GetUserbyId(UserId);
        if (user.SuperAdmin == true) return true;
        

            var UserRole = GetUserRoleByUserId(UserId);
        foreach (var item in UserRole)
        {
            if (item.RoleUniqName == "Admin")
            {
                return true;
            }
        }
        return false;
    }
}

