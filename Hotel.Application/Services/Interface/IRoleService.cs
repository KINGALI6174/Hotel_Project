using Hotel.Domain.Entities.Role;

namespace Hotel.Application.Services.Interface;

public interface IRoleService
{
    List<Role> GetUserRoleByUserId(int userId);
}