using Hotel.Application.Services.Interface;
using Hotel.Domain.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Areas.AdminPanel.Controllers;

public class UserController : AdminBaseController
{

    #region Ctor

    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    #endregion

    #region List Of User

    public IActionResult Index()
    {
        #region Get List Of user

        var users = _userService.ListOfUsers();
         if (users == null) return NotFound();
        
            #endregion
        return View();
    }
    

    #endregion
}

