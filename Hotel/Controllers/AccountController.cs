using System.Security.Claims;
using AspNetCoreHero.ToastNotification.Abstractions;
using Hotel.Application.DTOs.SiteSide.UserLogin;
using Hotel.Application.DTOs.SiteSide.UserRegister;
using Hotel.Application.Security;
using Hotel.Application.Services.Interface;
using Hotel.Domain.Entities.Account;
using Hotel.Infrastructuer.DbContext;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class AccountController : Controller
    {
        #region Ctor

        private readonly INotyfService _toastNotification;
        private readonly IUserService _userService;

        public AccountController(INotyfService toastNotification, IUserService userService)
        {
            _toastNotification = toastNotification;
            _userService = userService;
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
                bool Result = _userService.RegisterUser(UserDTO);
                if (Result)
                {
                    _toastNotification.Success("ثبت نام با موفقیت انجام شد .");
                    return RedirectToAction("Index", "Home");
                }
            }
            _toastNotification.Error("کاربر با این کد ملی قبلا ثبت نام شده است .");
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
                var user = _userService.GetUserByNationalCode(model.NationalCode);
                if (user != null)
                {
                    if (_userService.CheckPassword(model.NationalCode, model.Password))
                    {
                        var claims = new List<Claim>
                        {
                            new (ClaimTypes.NameIdentifier, user.ID.ToString()),
                            new (ClaimTypes.Name, user.NationalCode),
                        };

                        var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(claimIdentity);

                        var authProps = new AuthenticationProperties();
                        authProps.IsPersistent = model.RememberMe;

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProps);
                        _toastNotification.Information("ورود با موفقیت انجام شد");

                        return RedirectToAction("Index", "Home");
                    }
                    _toastNotification.Error("پسورد وارد شده صحیح نمی باشد");
                    return View();
                }
<<<<<<< HEAD
                _toastNotification.Error("کاربری با این شماره ملی یافت نشد");
=======
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
>>>>>>> 78d1bb00570448618eee940fe6a62a33cdf6cd4b
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
