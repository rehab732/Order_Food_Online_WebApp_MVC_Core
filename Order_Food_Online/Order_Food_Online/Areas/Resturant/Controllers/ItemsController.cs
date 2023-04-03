
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Order_Food_Online.Areas.Resturant.Models;
using Order_Food_Online.Repository;

namespace Order_Food_Online.Areas.Resturant.Controllers
{
    [Area("Resturant")]
    public class ItemsController : Controller
    {

        public static Dictionary<int, int> items = new Dictionary<int, int>();
        public static int RestaurantId;
        public ICRUDRepository<Items> ItemRepoService { get; }
        public ICRUDRepository<Resturants> ResturantRepoService { get; }
        public ICRUDRepository<Orders> OrdersRepoService { get; }

        public ICRUDRepository<OrderItems> OrderItemsRepoService { get; }



        //Customer 
        public ItemsController(ICRUDRepository<Items> itemRepoService, ICRUDRepository<Resturants> resturantRepoService,ICRUDRepository<Orders> OrdersRepoService1 , ICRUDRepository<OrderItems> OrderItemsRepoService1)
        {
            ItemRepoService = itemRepoService;
            ResturantRepoService= resturantRepoService;
            OrdersRepoService = OrdersRepoService1;
            OrderItemsRepoService = OrderItemsRepoService1;

        }

        // GET: Resturant/Items
        [Route("Resturant/Items")]
        public async Task<IActionResult> Index()
        {
            return View(ItemRepoService.GetAll());
        }

        [Route("Resturant/Items/Resto")]
        public async Task<IActionResult> Resto(int id)
        {
            return View(ItemRepoService.GetAll(id));
        }

        // GET: Resturant/Items/Details/5
        [Route("Resturant/Items/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if(id== null)
            {
                return NotFound();
            }
            var itemDetailed = ItemRepoService.GetDetails(id??0);

            if(itemDetailed == null)
            {
                return NotFound();
            }

            return View(itemDetailed);
        }

        // GET: Resturant/Items/Create
        [Route("Resturant/Items/Create")]
        public IActionResult Create()
        {
            ViewData["ResturantId"] = new SelectList(ResturantRepoService.GetAll(), "Id", "RestName");
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
                ItemRepoService.Insert(items);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ResturantId"] = new SelectList(ResturantRepoService.GetAll(), "Id", "RestLocation", items.ResturantId);
            return View(items);
        }

        // GET: Resturant/Items/Edit/5
        [Route("Resturant/Items/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var items = ItemRepoService.GetAll().Find(i => i.ItemsId == id);
            if (items == null)
            {
                return NotFound();
            }
            ViewData["ResturantId"] = new SelectList(ResturantRepoService.GetAll(), "Id", "RestLocation", items.ResturantId);
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
                    ItemRepoService.Update(ItemsId, items);
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
            ViewData["ResturantId"] = new SelectList(ResturantRepoService.GetAll(), "Id", "RestLocation", items.ResturantId);
            return View(items);
        }

        // GET: Resturant/Items/Delete/5
        [Route("Resturant/Items/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var items = ItemRepoService.GetDetails((int)id);

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
            var items = ItemRepoService.GetAll().Find(i => i.ItemsId == ItemsId);
            
            if (items != null)
            {
                ItemRepoService.Delete(items);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool ItemsExists(int id)
        {
          return ItemRepoService.GetAll().Any(e => e.ItemsId == id);
        }


        [Route("Resturant/Items/AddToDictionary")]
        public void AddToDictionary(int ItemsId, int Quantity)
        {
            if (!items.ContainsKey(ItemsId))
            {
                items.Add(ItemsId, Quantity);
            }
            else
            {

                items[ItemsId] = Quantity;
            }

            var item = ItemRepoService.GetbyID(ItemsId);
            RestaurantId = item.ResturantId;

        }
        public IActionResult CheckOut()
        {
            //int https://localhost:44385/Resturant/Orders/ConfirmOrder?TotalPrice=480.00&RestoID=RestoID
            ViewBag.Items = items;
            ViewBag.RestaurantId = RestaurantId;
            return View(ItemRepoService.GetAll());
        }

        //CustomerId here is static
        // (order id, restaurant id, customer id, location, total price, Payment method).
        public IActionResult ConfirmOrder(string TotalPrice,string RestaurantId , string Location)
        {
            ViewBag.TotalPrice =decimal.Parse(TotalPrice);
            int RestoID = int.Parse(RestaurantId);
            var resto = ResturantRepoService.GetbyID(RestoID);
            ViewBag.RestName = resto.RestName;
            ViewBag.Location = Location;

            ViewBag.RestoID = int.Parse(RestaurantId);
            Orders orders = new Orders()
            {
                RestaurantId= RestoID,
                CustomerId=1,
                Location = Location,
                TotalAmount= decimal.Parse(TotalPrice),
                OrderDate= DateTime.Now,
            };

            OrdersRepoService.Insert(orders);

            foreach (KeyValuePair<int, int> keyValuePair in items)
            {
                OrderItems orderItems = new OrderItems()
                {
                    OrderId = orders.Id,
                    ItemId = keyValuePair.Key,
                    Quantity = keyValuePair.Value,
                };
                OrderItemsRepoService.Insert(orderItems);
            }
            return View();
        }
    }
}
