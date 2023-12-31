using Hotel.Domain.Entities.Role;

namespace Hotel.Domain.RepositoryInterface;

public interface IRoleRepository
{
    List<Role> GetUserRoleByUserId(int userId);
}