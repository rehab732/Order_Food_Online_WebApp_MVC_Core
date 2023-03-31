using Microsoft.EntityFrameworkCore;
using Order_Food_Online.Areas.Resturant.Models;
using Order_Food_Online.Data;

namespace Order_Food_Online.Repository
{
    public class ItemRepoService : ICRUDRepository<Items>
    {
        private readonly ApplicationDbContext _context;

        public ItemRepoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(Items item)
        {
            _context.Remove(item);
            _context.SaveChangesAsync();
        }

        public List<Items> GetAll()
        {
            return _context.Items.Include(i => i.Resturants).ToList();
        }

        public List<Items> GetAll(int id)
        {
            return _context.Items.Include(i => i.Resturants).Where(e=>e.ResturantId== id).ToList();
        }

        public Items GetDetails(int id)
        {
            if (_context.Items == null)
            {
                return null;
            }

            var items = _context.Items
                .Include(i => i.Resturants)
                .FirstOrDefault(m => m.ItemsId == id);

            return items;
        }

        public void Insert(Items item)
        {
            _context.Items.Add(item);
            _context.SaveChangesAsync();
        }

        public void Update(int id, Items updatedItem)
        {
            var item = _context.Items.Find(id);
            item.ItemName = updatedItem.ItemName;
            item.ImageUrl = updatedItem.ImageUrl;
            item.Price = updatedItem.Price;
            _context.SaveChangesAsync();
        }
    }
}
