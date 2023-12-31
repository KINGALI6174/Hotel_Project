using Hotel.Application.Services.Interface;
using Hotel.Domain.Entities.Role;
using Hotel.Domain.RepositoryInterface;
using Hotel.Infrastructuer.Repository;

namespace Hotel.Application.Services.Implement;

public class RoleService : IRoleService
{
    #region Ctor

    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }


    #endregion

    public List<Role> GetUserRoleByUserId(int userId)
    {
        return _roleRepository.GetUserRoleByUserId(userId);
    }
}

