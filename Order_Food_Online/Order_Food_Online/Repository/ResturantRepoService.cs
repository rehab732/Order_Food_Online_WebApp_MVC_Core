using Microsoft.EntityFrameworkCore;
using Order_Food_Online.Areas.Resturant.Models;
using Order_Food_Online.Data;

namespace Order_Food_Online.Repository
{
    public class ResturantRepoService : ICRUDRepository<Resturants>
    {
        private readonly ApplicationDbContext _context;

        public ResturantRepoService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Resturants GetbyID(int id)
        {
            return _context.Resturants.Find(id);

        }

        public void Delete(Resturants rest)
        {
            _context.Remove(rest);
            _context.SaveChangesAsync();
        }

        public List<Resturants> GetAll()
        {
            return _context.Resturants.ToList();
        }

        public List<Resturants> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public Resturants GetDetails(int id)
        {
            return _context.Resturants.FirstOrDefault(r=> r.Id == id);
        }

        public void Insert(Resturants rest)
        {
            _context.Resturants.Add(rest);
            _context.SaveChangesAsync();
        }

        public void Update(int id, Resturants updatedItem)
        {
            var rest = _context.Resturants.Find(id);
            rest.RestName = updatedItem.RestName;
            rest.City = updatedItem.City;
            rest.RestLocation = updatedItem.RestLocation;
            
            _context.SaveChangesAsync();
        }
    }
}
