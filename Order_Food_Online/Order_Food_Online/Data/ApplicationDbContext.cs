using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Order_Food_Online.Areas.Admin.Models;
using Order_Food_Online.Areas.Resturant.Models;
using Order_Food_Online.Models;

namespace Order_Food_Online.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrdersItems { get; set; }
        public DbSet<Resturants> Resturants { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Admins> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("Users", "security");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles", "security");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "security");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "security");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "security");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "security");

            modelBuilder.Entity<OrderItems>(entity =>
            {

                entity.HasKey(k => new { k.OrderId, k.ItemId });
              
            });
            // modelBuilder.Entity<IdentityUserLogin<string>>()
            //.HasNoKey();

            modelBuilder.Entity<OrderItems>()
                .HasOne(o => o.Orders)
                .WithMany(i => i.OrderItems)
                .HasForeignKey(i => i.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

        }
        
    }
}