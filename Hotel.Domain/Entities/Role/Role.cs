

using System.ComponentModel.DataAnnotations;

namespace Hotel.Domain.Entities.Role;

    public class Role
    {
    #region Property

    public int ID { get; set; }
    [MaxLength(100)]
    [Required]
    public string RoleTitle { get; set; }
    [MaxLength(100)]
    [Required]
    public string RoleUniqName { get; set; }

    public bool IsDelete { get; set; }

    public DateTime CreateDate { get; set; }


    #endregion

    #region Relation

    public ICollection<UserSelectedRole> UserSelectedRoles { get; set; }

    #endregion
}

