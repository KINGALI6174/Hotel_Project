using AspNetCoreHero.ToastNotification.Abstractions;
using Hotel.Application.DTOs.SiteSide.UserRegister;
using Hotel.Application.Security;
using Hotel.Domain.Entities.Account;
using Hotel.Infrastructuer.DbContext;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Hotel.Controllers
{
    public class AccountController : Controller
    {
        private readonly IToastNotification _toast;
        private readonly INotyfService _toastNotification;
        private readonly HotelDbContext _context;

        public AccountController(IToastNotification toast, INotyfService toastNotification, HotelDbContext context)
        {
            _toast = toast;
            _toastNotification = toastNotification;
            _context = context;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Register(UserRegisterDTO UserDTO)
        {
            if (ModelState.IsValid)
            {
                if (_context.Users.Any(u => u.Email == UserDTO.Email.Trim()) == false)
                {
                    Domain.Entities.Account.User user = new User()
                    {
                        Email = UserDTO.Email.Trim(),
                        Password = PasswordHelper.EncodePasswordMd5(UserDTO.Password),
                    };
                    _context.Users.Add(user);
                    _context.SaveChanges();

                    //_toast.AddSuccessToastMessage("ثبت نام با موفقیت انجام شد");
                    _toastNotification.Success("ثبت نام با موفقیت انجام شد .");
                    //_toastNotification.Success("he");
                    return RedirectToAction("Index", "Home");
                }
                //_toast.AddErrorToastMessage("این ایمیل قبلا ثبت نام شده است .");
                _toastNotification.Error("  این ایمیل قبلا ثبت نام شده است .");
            }
            return View();
        }
    }
}
