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
            throw new NotImplementedException();
        }

        public List<OrderItems> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<OrderItems> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public OrderItems GetDetails(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(OrderItems item)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, OrderItems updatedItem)
        {
            throw new NotImplementedException();
        }
    }
}
