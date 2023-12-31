using Hotel.Domain.Entities.Role;
using Hotel.Domain.RepositoryInterface;
using Hotel.Infrastructuer.DbContext;

namespace Hotel.Infrastructuer.Repository;

public class RoleRepository : IRoleRepository
{
    #region Ctor

    private readonly HotelDbContext _context;

    public RoleRepository(HotelDbContext context)
    {
        _context = context;
    }


    #endregion

    public List<Role> GetUserRoleByUserId(int userId)
    {
        var role = _context.UserSelectedRoles
                                .Where(p => p.UserId == userId)
                                .Select(p => p.Role)
                                .ToList();  
        return role;
    }
}

