using AspNetCoreHero.ToastNotification.Abstractions;
using Hotel.Application.DTOs.AdminSide.Product;
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

        private readonly INotyfService _toast;
        private IHotelService _Service;

        public ProductController(INotyfService toast, IHotelService service)
        {
            _toast = toast;
            _Service = service;
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
                    var hotel = new Domain.Entities.Product.Hotel()
                    {
                        Title = model.Title,
                        DateTime = DateTime.Now,
                        Description = model.Description,
                        EntryTime = model.EntryTime,
                        ExitTime = model.ExitTime,
                        RoomCount = model.RoomCount,
                        StageCount = model.StageCount,
                    };
                    _Service.AddHotel(hotel);

                    var address = new HotelAddress()
                    {
                        Address = model.Address,
                        City = model.City,
                        State = model.State,
                        HotelId = hotel.ID,
                    };
                    hotel.IsActive = true;
                    _Service.InsetAddress(address);
                    
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

        #region Edit

        public IActionResult EditHotel()
        {
            return View();
        }

        #endregion


    }
}
