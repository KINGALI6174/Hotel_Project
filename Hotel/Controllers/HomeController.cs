using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Hotel.Infrastructuer.DbContext;

namespace Hotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HotelDbContext _Context;

        public HomeController(ILogger<HomeController> logger, HotelDbContext hotelDbContext)
        {
            _logger = logger;
            _Context = hotelDbContext;
        }

        public IActionResult Index()
        {
            var baner = _Context.FirstBaners.ToList();
            TempData["MainPage"] = "MainPage";
            return View(baner);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}