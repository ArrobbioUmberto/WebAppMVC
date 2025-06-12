using Microsoft.EntityFrameworkCore;
using WebAppMVC.Entity;


namespace WebAppMVC.Data
{
    public class ShopContext : DbContext
    {
        public DbSet<Item> Products { get; set; }

        public ShopContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().OwnsOne(i => i.FullPrice);
            modelBuilder.Entity<Item>().OwnsOne(i => i.Discount);
            base.OnModelCreating(modelBuilder);
        }

    }
}
