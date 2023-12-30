using Hotel.Domain.Entities.Account;

namespace Hotel.Domain.Entities.Role;

public class UserSelectedRole
{
    #region Property

    public int ID { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }


    #endregion

    #region Relation
     public Role Role { get; set; }
     public User User { get; set; } 
    

    #endregion
}

