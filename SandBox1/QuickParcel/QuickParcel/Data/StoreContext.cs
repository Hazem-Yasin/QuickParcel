using QuickParcel.Models;
using Microsoft.EntityFrameworkCore;

namespace QuickParcel.Data
{
    public class StoreContext : DbContext
    {
        public  StoreContext(DbContextOptions<StoreContext> options) : base(options) {}

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Customer>().ToTable("Customer");
        }

    }
}



//when the database is created
//ef creates tables that have names the same as the DbSet property names
//Property names for collections are typically plural,
//for example, Students rather than Student
//developers disagree about this wether the names should be plural or not
//like should it be Customer or Customers