using Microsoft.EntityFrameworkCore;
using QuickParcelApi.Models;

namespace QuickParcelApi.Data
{
    public class QuickParcelDbContext:DbContext
    {

        public QuickParcelDbContext(DbContextOptions<QuickParcelDbContext> options) : base(options) { }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Product>().ToTable("Product");
        }

    }
}
