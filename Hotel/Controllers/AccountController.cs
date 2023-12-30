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
using NToastNotify;

namespace Hotel.Controllers
{
    public class AccountController : Controller
    {
        #region Ctor

        private readonly INotyfService _toastNotification;
        private readonly IHotelService _hotelService;

        public AccountController(INotyfService toastNotification, IHotelService hotelService)
        {
            _toastNotification = toastNotification;
            _hotelService = hotelService;
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
                bool Result = _hotelService.RegisterUser(UserDTO);
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
                var user = _hotelService.GetUserByNationalCode(model.NationalCode);
                if (user != null)
                {
                    if (_hotelService.CheckPassword(model.NationalCode, model.Password))
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
                _toastNotification.Error("کاربری با این شماره ملی یافت نشد");
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


    }
}
