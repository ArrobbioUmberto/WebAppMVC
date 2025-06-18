using Microsoft.EntityFrameworkCore;
using WebAppMVC.Entity;


namespace WebAppMVC.Data
{
    public class ShopContext : DbContext
    {
        public DbSet<Item> Products { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<Roles> Roles { get; set; }

        public ShopContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().OwnsOne(i => i.FullPrice);
            modelBuilder.Entity<Item>().OwnsOne(i => i.Discount);
            // Configurazione della relazione tra la tabella Products e Category
            modelBuilder.Entity<Item>()
                .HasOne(i => i.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(i => i.CategoryId);
            modelBuilder.Entity<Users>()
                .HasOne(i => i.Role)
                .WithMany(c => c.Users)
                .HasForeignKey(i => i.RoleId);
            base.OnModelCreating(modelBuilder);
        }

    }
}
