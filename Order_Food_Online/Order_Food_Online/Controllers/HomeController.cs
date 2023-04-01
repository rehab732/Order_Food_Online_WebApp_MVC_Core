using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Order_Food_Online.Areas.Resturant.Models;
using Order_Food_Online.Models;
using Order_Food_Online.Repository;
using System.Diagnostics;

namespace Order_Food_Online.Controllers
{
    public class HomeController : Controller
    {
        public static Dictionary<int,int>  items = new Dictionary<int, int>();

        //ID,QUNATITY,PRICE


        private readonly ILogger<HomeController> _logger;
        private ICRUDRepository<Resturants> crudRepository { get; }

      
        public HomeController(ILogger<HomeController> logger, ICRUDRepository<Resturants> cRUDRepository)
        {
            crudRepository = cRUDRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View(crudRepository.GetAll().ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public void AddToDictionary(int ItemsId, int Quantity)
        {
            if(!items.ContainsKey(ItemsId))
            {
                items.Add(ItemsId, Quantity);
            }
            else
            {

            items[ItemsId] = Quantity;
            }
        }
    }
}