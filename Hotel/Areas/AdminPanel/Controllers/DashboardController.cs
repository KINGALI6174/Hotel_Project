using Hotel.Application.Extensions;
using Hotel.Application.Services.Interface;
using Hotel.Areas.AdminPanel.ActionFliterAttribuutes;
using Hotel.Domain.Entities.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Areas.AdminPanel.Controllers
{
<<<<<<< HEAD
    
    public class DashboardController : AdminBaseController
    {
        #region Ctor

        private readonly IRoleService _roleService;

        public DashboardController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        

        #endregion
=======

    [Area("AdminPanel")]
    [Authorize]
    public class DashboardController : Controller
    {
>>>>>>> 78d1bb00570448618eee940fe6a62a33cdf6cd4b
        public IActionResult Index()
        {
            return View();
        }
    }
}
