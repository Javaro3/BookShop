using BookShop.Domains.Entities;
using BookShop.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.Persistence;

public class BookShopDbContext(DbContextOptions<BookShopDbContext> options) : DbContext(options)
{
    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Order> Orders { get; set; }
    
    public virtual DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new BookConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
    }
}