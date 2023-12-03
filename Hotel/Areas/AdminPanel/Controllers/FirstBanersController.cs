using Hotel.Infrastructuer.DbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class FirstBanersController : Controller
    {
        private readonly HotelDbContext _context;

        public FirstBanersController(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.FirstBaners.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null || _context.FirstBaners == null)
            {
                return NotFound();
            }
            
            var FirstBaner = await _context.FirstBaners.FirstOrDefaultAsync(b => b.ID == id);
            if (FirstBaner == null)
            {
                return NotFound();
            }
            return View(FirstBaner);
        }
    }
}
