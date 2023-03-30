using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Order_Food_Online.Areas.Resturant.Models;
using Order_Food_Online.Repository;

namespace Order_Food_Online.Areas.Resturant.Controllers
{
    [Area("Resturant")]
    public class ResturantsController : Controller
    {
        private ICRUDRepository<Resturants> crudRepository { get; }

        public ResturantsController(ICRUDRepository<Resturants> cRUDRepository)
        {   
            crudRepository = cRUDRepository;
        }

        // GET: Resturant/Resturants
        [Route("Resturant/Resturants")]
        public async Task<IActionResult> Index()
        {
            return View(crudRepository.GetAll().ToList());
        }

        // GET: Resturant/Resturants/Details/5
        [Route("Resturant/Resturants/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resturants = crudRepository.GetDetails((int)id);
                
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
                crudRepository.Insert(resturants);
                return RedirectToAction(nameof(Index));
            }
            return View(resturants);
        }

        // GET: Resturant/Resturants/Edit/5
        [Route("Resturant/Resturants/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resturants = crudRepository.GetDetails((int)id);

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
                    crudRepository.Update(id, resturants);
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
            if (id == null)
            {
                return NotFound();
            }

            var resturants = crudRepository.GetDetails((int)id);

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
            
            var resturants = crudRepository.GetDetails(id);

            if (resturants != null)
            {
                crudRepository.Delete(resturants);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool ResturantsExists(int id)
        {
          return (crudRepository.GetAll().Any(e => e.Id == id));
        }
    }
}
