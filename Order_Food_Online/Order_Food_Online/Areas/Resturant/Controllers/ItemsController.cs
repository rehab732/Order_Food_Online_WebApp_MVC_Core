
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Order_Food_Online.Areas.Resturant.Models;
using Order_Food_Online.Data;

namespace Order_Food_Online.Areas.Resturant.Controllers
{
    [Area("Resturant")]
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Resturant/Items
        [Route("Resturant/Items")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Items.Include(i => i.Resturants);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Resturant/Items/Details/5
        [Route("Resturant/Items/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var items = await _context.Items
                .Include(i => i.Resturants)
                .FirstOrDefaultAsync(m => m.ItemsId == id);
            if (items == null)
            {
                return NotFound();
            }

            return View(items);
        }

        // GET: Resturant/Items/Create
        [Route("Resturant/Items/Create")]
        public IActionResult Create()
        {
            ViewData["ResturantId"] = new SelectList(_context.Resturants, "Id", "RestLocation");
            return View();
        }

        // POST: Resturant/Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Resturant/Items/Create")]
        public async Task<IActionResult> Create([Bind("ItemsId,ItemName,ImageUrl,Price,ResturantId")] Items items)
        {
            if (ModelState.IsValid)
            {
                _context.Add(items);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ResturantId"] = new SelectList(_context.Resturants, "Id", "RestLocation", items.ResturantId);
            return View(items);
        }

        // GET: Resturant/Items/Edit/5
        [Route("Resturant/Items/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var items = await _context.Items.FindAsync(id);
            if (items == null)
            {
                return NotFound();
            }
            ViewData["ResturantId"] = new SelectList(_context.Resturants, "Id", "RestLocation", items.ResturantId);
            return View(items);
        }

        // POST: Resturant/Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Resturant/Items/Edit")]
        public async Task<IActionResult> Edit(int ItemsId, [Bind("ItemsId,ItemName,ImageUrl,Price,ResturantId")] Items items)
        {
            if (ItemsId != items.ItemsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(items);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemsExists(items.ItemsId))
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
            ViewData["ResturantId"] = new SelectList(_context.Resturants, "Id", "RestLocation", items.ResturantId);
            return View(items);
        }

        // GET: Resturant/Items/Delete/5
        [Route("Resturant/Items/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var items = await _context.Items
                .Include(i => i.Resturants)
                .FirstOrDefaultAsync(m => m.ItemsId == id);
            if (items == null)
            {
                return NotFound();
            }

            return View(items);
        }

        // POST: Resturant/Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Resturant/Items/Delete")]
        public async Task<IActionResult> DeleteConfirmed(int ItemsId)
        {
            if (_context.Items == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Items'  is null.");
            }
            var items = await _context.Items.FindAsync(ItemsId);
            if (items != null)
            {
                _context.Items.Remove(items);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemsExists(int id)
        {
          return (_context.Items?.Any(e => e.ItemsId == id)).GetValueOrDefault();
        }
    }
}
