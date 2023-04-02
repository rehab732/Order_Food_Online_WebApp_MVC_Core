using Microsoft.EntityFrameworkCore;
using Order_Food_Online.Areas.Resturant.Models;
using Order_Food_Online.Data;

namespace Order_Food_Online.Repository
{
    public class OrderRepoService : ICRUDRepository<Orders>
    {
        private readonly ApplicationDbContext _context;

        public OrderRepoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(Orders orders)
        {
            _context.Remove(orders);
            _context.SaveChangesAsync();
        }

        public List<Orders> GetAll()
        {
            return _context.Orders.Include(i => i.OrderItems).ToList();
        }

        public List<Orders> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public Orders GetbyID(int id)
        {
            return _context.Orders.Find(id);

        }

        public Orders GetDetails(int id)
        {
            if (_context.Orders == null)
            {
                return null;
            }

            var order = _context.Orders
                .Include(i => i.OrderItems)
                .FirstOrDefault(m => m.Id == id);

            return order;
        }

        public void Insert(Orders orders)
        {
            _context.Orders.Add(orders);
            _context.SaveChangesAsync();
        }

        public void Update(int id, Orders updatedOrder)
        {
            var orders = _context.Orders.Find(id);
            orders.Location = updatedOrder.Location;
            orders.RestaurantId = updatedOrder.RestaurantId;
            orders.TotalAmount = updatedOrder.TotalAmount;
            _context.SaveChangesAsync();
        }
    }
}

