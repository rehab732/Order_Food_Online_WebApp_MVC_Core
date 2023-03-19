using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Order_Food_Online.Areas.Admin.Models;
using Order_Food_Online.Areas.Customer.Models;
using Order_Food_Online.Areas.Resturant.Models;

namespace Order_Food_Online.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        DbSet<Customers> Customers { get; set; }
        DbSet<Orders> Orders { get; set; }
        DbSet<OrderItems> OrdersItems { get; set; }
        DbSet<Resturants> Resturants { get; set; }
        DbSet<Items> Items { get; set; }
        DbSet<Admins> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItems>(entity =>
            {

                entity.HasKey(k => new { k.OrderId, k.ItemId });
            });
            // modelBuilder.Entity<IdentityUserLogin<string>>()
            //.HasNoKey();
            base.OnModelCreating(modelBuilder);
        }
        
    }
}