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
    
    public class ProductController : AdminBaseController
    {
        #region Ctor

        private readonly IHotelService _Service;
        private readonly INotyfService _toast;

        public ProductController(IHotelService service, INotyfService toast)
        {
            _Service = service;
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

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CreateHotel(CreateHotelDTO model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _Service.CreateHotel(model);
                    _toast.Success("عملیات با موفقیت انجام شد");
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

        public IActionResult EditHotel(int id)
        {
            var hotel = _Service.GetHotelById(id);
            return View(hotel);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult EditHotel(EditHotelDTO hotel)
        {
            if (ModelState.IsValid)
            {
                _Service.UpdateHotel(hotel);
                _toast.Success("تغییرات با موفقیت انجام شد");
                return RedirectToAction("ShowAllHotels");
            }
            return View(hotel);
        }
        
        #endregion


    }
}



