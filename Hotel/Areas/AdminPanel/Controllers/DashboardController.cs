using Hotel.Application.Extensions;
using Hotel.Application.Services.Interface;
using Hotel.Areas.AdminPanel.ActionFliterAttribuutes;
using Hotel.Domain.Entities.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Areas.AdminPanel.Controllers
{
    
    public class DashboardController : AdminBaseController
    {
        #region Ctor

        private readonly IRoleService _roleService;

        public DashboardController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        

        #endregion
        public IActionResult Index()
        {
            return View();
        }
    }
}
