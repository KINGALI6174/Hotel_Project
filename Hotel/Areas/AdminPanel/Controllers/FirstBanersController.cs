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
    [Area("AdminPanel")]
    [Authorize]
    public class FirstBanersController : Controller
    {
        private readonly HotelDbContext _context;

        public FirstBanersController(HotelDbContext context)
        {
            _context = context;
        }

        // GET: AdminPanel/FirstBaners
        public async Task<IActionResult> Index()
        {
              return _context.FirstBaners != null ? 
                          View(await _context.FirstBaners.ToListAsync()) :
                          Problem("Entity set 'HotelDbContext.FirstBaners'  is null.");
        }

        // GET: AdminPanel/FirstBaners/Details/5
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

        // GET: AdminPanel/FirstBaners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/FirstBaners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: AdminPanel/FirstBaners/Edit/5
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

        // POST: AdminPanel/FirstBaners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: AdminPanel/FirstBaners/Delete/5
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

        // POST: AdminPanel/FirstBaners/Delete/5
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

        private bool FirstBanerExists(int id)
        {
          return (_context.FirstBaners?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
