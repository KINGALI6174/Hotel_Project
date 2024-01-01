using Hotel.Areas.AdminPanel.ActionFliterAttribuutes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    [CheckUserAdminRole]
    public class AdminBaseController : Controller
    {
    }
}
