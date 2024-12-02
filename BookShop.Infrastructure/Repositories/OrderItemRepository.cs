using System.Linq.Expressions;
using BookShop.Domains.Entities;
using BookShop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.Repositories;

public class OrderItemRepository : Repository<OrderItem>
{
    private readonly Expression<Func<OrderItem, OrderItem>> _selector = orderItem => new OrderItem
    {
        Id = orderItem.Id,
        OrderId = orderItem.OrderId,
        Order = new Order
        {
            Id = orderItem.Order.Id,
            OrderNumber = orderItem.Order.OrderNumber,
            OrderDate = orderItem.Order.OrderDate,
        },
        BookId = orderItem.BookId,
        Book = new Book
        {
            Id = orderItem.Book.Id,
            Title = orderItem.Book.Title,
            Author = orderItem.Book.Author,
            Description = orderItem.Book.Description,
            Pages = orderItem.Book.Pages,
            Price = orderItem.Book.Price,
            PublicationDate = orderItem.Book.PublicationDate,
        },
        Quantity = orderItem.Quantity
    };
    
    public OrderItemRepository(BookShopDbContext context) : base(context)
    {
    }
    
    public override IQueryable<OrderItem> GetAll()
    {
        return DbSet
            .Include(e => e.Order)
            .Include(e => e.Book)
            .Select(_selector)
            .AsQueryable();
    }

    public override Task<OrderItem?> GetByIdAsync(int id)
    {
        return DbSet
            .Include(e => e.Order)
            .Include(e => e.Book)
            .Select(_selector)
            .FirstOrDefaultAsync(e => e.Id == id);
    }
}