using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using NuGet.Configuration;
using Order_Food_Online.Areas.Resturant.Models;
using Order_Food_Online.Models;
using Order_Food_Online.Repository;
using System.Diagnostics;

namespace Order_Food_Online.Controllers
{
    public class HomeController : Controller
    {
        //ID,QUNATITY,PRICE


        private readonly ILogger<HomeController> _logger;
        public ICRUDRepository<Items> ItemRepoService { get; }

        private ICRUDRepository<Resturants> crudRepository { get; }

        public HomeController(ICRUDRepository<Items> ItemsRepos,ILogger<HomeController> logger, ICRUDRepository<Resturants> cRUDRepository)
        {
            crudRepository = cRUDRepository;
            _logger = logger;
            ItemRepoService= ItemsRepos;
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
    }
}