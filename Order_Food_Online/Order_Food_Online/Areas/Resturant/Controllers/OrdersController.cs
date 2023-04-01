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
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Resturant/Orders
        [Route("Resturant/Orders/Index")]

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Orders.Include(o => o.Customer).Include(o => o.Restaurant);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Resturant/Orders/Details/5
        [Route("Resturant/Orders/Details")]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Restaurant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // GET: Resturant/Orders/Create
        [Route("Resturant/Orders/Create")]

        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FirstName");
            ViewData["RestaurantId"] = new SelectList(_context.Resturants, "Id", "RestName");
            return View();
        }

        // POST: Resturant/Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Resturant/Orders/Create")]

        public async Task<IActionResult> Create([Bind("Id,CustomerId,RestaurantId,Location,OrderDate,TotalAmount")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FirstName", orders.CustomerId);
            ViewData["RestaurantId"] = new SelectList(_context.Resturants, "Id", "RestName", orders.RestaurantId);
            return View(orders);
        }

        // GET: Resturant/Orders/Edit/5
        [Route("Resturant/Orders/Edit")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FirstName", orders.CustomerId);
            ViewData["RestaurantId"] = new SelectList(_context.Resturants, "Id", "RestName", orders.RestaurantId);
            return View(orders);
        }

        // POST: Resturant/Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Resturant/Orders/Edit")]

        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,RestaurantId,Location,OrderDate,TotalAmount")] Orders orders)
        {
            if (id != orders.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FirstName", orders.CustomerId);
            ViewData["RestaurantId"] = new SelectList(_context.Resturants, "Id", "RestName", orders.RestaurantId);
            return View(orders);
        }

        // GET: Resturant/Orders/Delete/5
        [Route("Resturant/Orders/Delete")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Restaurant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // POST: Resturant/Orders/Delete/5
       
        [HttpPost, ActionName("Delete")]
        [Route("Resturant/Orders/Delete")]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Orders'  is null.");
            }
            var orders = await _context.Orders.FindAsync(id);
            if (orders != null)
            {
                _context.Orders.Remove(orders);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersExists(int id)
        {
          return (_context.Orders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
