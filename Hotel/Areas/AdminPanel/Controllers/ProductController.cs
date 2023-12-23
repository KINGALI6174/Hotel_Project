using AspNetCoreHero.ToastNotification.Abstractions;
using Hotel.Application.DTOs.AdminSide.Product;
using Hotel.Application.Services.Interface;
using Hotel.Domain.Entities.Product;
using Hotel.Domain.RepositoryInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hotel = Hotel.Domain.Entities.Product.Hotel;

namespace Hotel.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    public class ProductController : Controller
    {
        #region Ctor

        private readonly IDashboardService _Service;
        private readonly INotyfService _toast;

        public ProductController(IDashboardService boardService, INotyfService toast)
        {
            _Service = boardService;
            _toast = toast;
        }

        #endregion
        public IActionResult ShowAllHotels()
        {
            return View(_Service.GetAllHotel());
        }

        #region Create Hotel

        public IActionResult CreateHotel()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult CreateHotel(CreateHotelDTO model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _Service.CreateHotel(model);
                    
                    _toast.Success("هتل با موفقیت ثبت شد");
                    return RedirectToAction("ShowAllHotels");
                }
                catch (Exception e)
                {
                    _toast.Error("عملیات با خطا مواجه شد.");
                    return View(model);
                }
            }
            else
            {
                _toast.Error("لطفا تمامی فیلد ها پر نمایید");
                return View(model);
            }
        }


        #endregion

        #region Edit Hotel

        public IActionResult EditHotel(EditHotelDTO model)
        {
            
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult EditHotel(int id,Domain.Entities.Product.Hotel hotel,HotelAddress hotelAddress)
        {
            _Service.UpdateHotel(hotel);
            _Service.UpdateAddress(hotelAddress);
            return RedirectToAction("ShowAllHotels");
        }

        #endregion


    }
}
