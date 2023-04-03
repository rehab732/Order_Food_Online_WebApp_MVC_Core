using Order_Food_Online.Areas.Resturant.Models;
using Order_Food_Online.Data;

namespace Order_Food_Online.Repository
{
    public class OrderItemsRepoService : ICRUDRepository<OrderItems>
    {
        private readonly ApplicationDbContext _context;

        public OrderItemsRepoService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Delete(OrderItems item)
        {
            _context.Remove(item);
            _context.SaveChangesAsync();
        }

        public List<OrderItems> GetAll()
        {
            return _context.OrdersItems.ToList();

        }

        public List<OrderItems> GetAll(int id)
        {
            throw new NotImplementedException();

        }

        public OrderItems GetbyID(int id)
        {
            throw new NotImplementedException();
        }

        public OrderItems GetDetails(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(OrderItems item)
        {
            _context.OrdersItems.Add(item);
            _context.SaveChangesAsync();
        }

        public void Update(int id, OrderItems updatedItem)
        {
            throw new NotImplementedException();
        }
    }
}
