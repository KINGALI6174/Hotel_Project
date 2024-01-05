using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel.Domain.Entities.Web;
using Hotel.Infrastructuer.DbContext;
using Microsoft.AspNetCore.Authorization;

namespace Hotel.Areas.AdminPanel.Controllers
{
<<<<<<< HEAD
    
    public class FirstBanersController : AdminBaseController
=======
    [Area("AdminPanel")]
    [Authorize]
    public class FirstBanersController : Controller
>>>>>>> 78d1bb00570448618eee940fe6a62a33cdf6cd4b
    {
        #region Ctor

        private readonly HotelDbContext _context;

        public FirstBanersController(HotelDbContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
              return _context.FirstBaners != null ? 
                          View(await _context.FirstBaners.ToListAsync()) :
                          Problem("Entity set 'HotelDbContext.FirstBaners'  is null.");
        }

        #region Details

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FirstBaners == null)
            {
                return NotFound();
            }

            var firstBaner = await _context.FirstBaners
                .FirstOrDefaultAsync(m => m.ID == id);
            if (firstBaner == null)
            {
                return NotFound();
            }

            return View(firstBaner);
        }

        #endregion

        #region Create

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,banerTitle,banerBotton,ImageName")] FirstBaner firstBaner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(firstBaner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(firstBaner);
        }


        #endregion

        #region Edit

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FirstBaners == null)
            {
                return NotFound();
            }

            var firstBaner = await _context.FirstBaners.FindAsync(id);
            if (firstBaner == null)
            {
                return NotFound();
            }
            return View(firstBaner);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,banerTitle,banerBotton,ImageName")] FirstBaner firstBaner)
        {
            if (id != firstBaner.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(firstBaner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FirstBanerExists(firstBaner.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(firstBaner);
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FirstBaners == null)
            {
                return NotFound();
            }

            var firstBaner = await _context.FirstBaners
                .FirstOrDefaultAsync(m => m.ID == id);
            if (firstBaner == null)
            {
                return NotFound();
            }

            return View(firstBaner);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FirstBaners == null)
            {
                return Problem("Entity set 'HotelDbContext.FirstBaners'  is null.");
            }
            var firstBaner = await _context.FirstBaners.FindAsync(id);
            if (firstBaner != null)
            {
                _context.FirstBaners.Remove(firstBaner);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        private bool FirstBanerExists(int id)
        {
          return (_context.FirstBaners?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
