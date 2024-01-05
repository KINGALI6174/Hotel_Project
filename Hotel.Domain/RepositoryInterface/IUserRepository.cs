using Hotel.Domain.Entities.Account;
namespace Hotel.Domain.RepositoryInterface;

public interface IUserRepository
{
    #region General Methodes

    bool IsExistByNatinalCode(string natinalCode);
    public void AddUserToDataBase(User user);
    public void SaveChange();
    User GetUserByNationalCode(string nationalCode);
    bool CheckPassword(string nationalCode, string Password);
    User GetUserbyId(int userId);

    #endregion

    #region Admin Side Methods

    List<User> ListOfUsers();

    #endregion


}