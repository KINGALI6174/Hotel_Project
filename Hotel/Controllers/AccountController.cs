using System.Security.Claims;
using AspNetCoreHero.ToastNotification.Abstractions;
using Hotel.Application.DTOs.SiteSide.UserLogin;
using Hotel.Application.DTOs.SiteSide.UserRegister;
using Hotel.Application.Security;
using Hotel.Domain.Entities.Account;
using Hotel.Infrastructuer.DbContext;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Hotel.Controllers
{
    public class AccountController : Controller
    {
        #region Ctor
        private readonly IToastNotification _toast;
        private readonly INotyfService _toastNotification;
        private readonly HotelDbContext _context;

        public AccountController(IToastNotification toast, INotyfService toastNotification, HotelDbContext context)
        {
            _toast = toast;
            _toastNotification = toastNotification;
            _context = context;
        }

        #endregion

        #region Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Register(UserRegisterDTO UserDTO)
        {
            if (ModelState.IsValid)
            {
                if (_context.Users.Any(u => u.NationalCode == UserDTO.NationalCode.Trim()) == false)
                {
                    Domain.Entities.Account.User user = new User()
                    {
                        FName = UserDTO.FName,
                        LName = UserDTO.LName,
                        NationalCode = UserDTO.NationalCode,
                        PhoneNumber = UserDTO.PhoneNumber,
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
                _toastNotification.Error("کاربر با این کد ملی قبلا ثبت نام شده است .");
            }
            return View();
        }

        #endregion


        #region Login

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginDTO model)
        {
            if (ModelState.IsValid)
            {
                #region Find User
                var user = _context.Users.FirstOrDefault(u => u.NationalCode == model.NationalCode.Trim()
                                                              && u.Password == PasswordHelper.EncodePasswordMd5(model.Password));
                if (user == null)
                {
                    _toastNotification.Error("مشخصات وارد شده صحیح نمی باشد");
                    return View("Login");
                }
                #endregion

                #region setting cooki

                var claims = new List<Claim>
                {
                    new (ClaimTypes.NameIdentifier, user.ID.ToString()),
                    new (ClaimTypes.Name, user.FName),
                };

                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(claimIdentity);

                var authProps = new AuthenticationProperties();
                authProps.IsPersistent = model.RememberMe;

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProps);
                _toastNotification.Information("ورود با موفقیت انجام شد");

                return RedirectToAction("Index", "Home");

                #endregion
            }
            return View();
        }

        #endregion


        #region Logout

        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        #endregion


        #region User Dashbord

        public IActionResult UserDashborad()
        {
            if (User.Identity.IsAuthenticated)
            {
            return View();
            }
            _toastNotification.Warning("لطفا ابتدا وارد شوید");
            return RedirectToAction("Login");
        }

        #endregion

    }
}
