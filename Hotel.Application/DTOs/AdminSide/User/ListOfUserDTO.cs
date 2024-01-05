using System.ComponentModel.DataAnnotations;

namespace Hotel.Application.DTOs.AdminSide.User;

public class ListOfUserDTO
{
    #region Property
    public int ID { get; set; }
    public string LName { get; set; }
    public string NationalCode { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public DateTime CreateDate { get; set; }
    public string? UserAvatar { get; set; }

    #endregion

}

