using Hotel.Domain.Entities.Account;
using Hotel.Domain.RepositoryInterface;
using Hotel.Infrastructuer.DbContext;

namespace Hotel.Infrastructuer.Repository;

public class UserRepository : IUserRepository
{
    #region Ctor

    private readonly HotelDbContext _context;

    public UserRepository(HotelDbContext context)
    {
        _context = context;
    }

    #endregion

    #region General Methods

    public User? GetUserbyId(int userId)
    {
        return _context.Users.Find(userId);
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
        return _context.Users.SingleOrDefault(p => p.IsDelete == false && p.NationalCode == nationalCode);
    }

    public bool CheckPassword(string nationalCode, string Password)
    {
        var user = GetUserByNationalCode(nationalCode);
        bool result = user.Password == Password;
        return result;
    }

    #endregion

    #region Admin Side methods

    public List<User> ListOfUsers()
    {
        return _context.Users
                    .Where( p => !p.IsDelete)
                    .OrderByDescending(p => p.)
    }

    #endregion

}

