using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Order_Food_Online.Areas.Resturant.Models;
using Order_Food_Online.Data;

namespace Order_Food_Online.Areas.Resturant.Controllers
{
    [Area("Resturant")]
    public class ResturantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResturantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Resturant/Resturants
        [Route("Resturant/Resturants")]
        public async Task<IActionResult> Index()
        {
              return _context.Resturants != null ? 
                          View(await _context.Resturants.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Resturants'  is null.");
        }

        // GET: Resturant/Resturants/Details/5
        [Route("Resturant/Resturants/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Resturants == null)
            {
                return NotFound();
            }

            var resturants = await _context.Resturants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resturants == null)
            {
                return NotFound();
            }

            return View(resturants);
        }

        // GET: Resturant/Resturants/Create
        [Route("Resturant/Resturants/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Resturant/Resturants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Resturant/Resturants/Create")]
        public async Task<IActionResult> Create([Bind("Id,RestName,City,RestLocation")] Resturants resturants)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resturants);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resturants);
        }

        // GET: Resturant/Resturants/Edit/5
        [Route("Resturant/Resturants/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Resturants == null)
            {
                return NotFound();
            }

            var resturants = await _context.Resturants.FindAsync(id);
            if (resturants == null)
            {
                return NotFound();
            }
            return View(resturants);
        }

        // POST: Resturant/Resturants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Resturant/Resturants/Edit")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RestName,City,RestLocation")] Resturants resturants)
        {
            if (id != resturants.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resturants);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResturantsExists(resturants.Id))
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
            return View(resturants);
        }

        // GET: Resturant/Resturants/Delete/5
        [Route("Resturant/Resturants/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Resturants == null)
            {
                return NotFound();
            }

            var resturants = await _context.Resturants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resturants == null)
            {
                return NotFound();
            }

            return View(resturants);
        }

        // POST: Resturant/Resturants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Resturant/Resturants/Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Resturants == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Resturants'  is null.");
            }
            var resturants = await _context.Resturants.FindAsync(id);
            if (resturants != null)
            {
                _context.Resturants.Remove(resturants);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResturantsExists(int id)
        {
          return (_context.Resturants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
