using Microsoft.AspNetCore.Mvc;

namespace Hotel.Areas.AdminPanel.Controllers;

public class UserController : AdminBaseController
{

    #region Ctor

    private readonly 

    #endregion

    #region List Of User

    public IActionResult Index()
    {
        return View();
    }
    

    #endregion
}

