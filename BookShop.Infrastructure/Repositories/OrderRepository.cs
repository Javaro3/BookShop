using System.Linq.Expressions;
using BookShop.Domains.Entities;
using BookShop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.Repositories;

public class OrderRepository : Repository<Order>
{
    private readonly Expression<Func<Order, Order>> _selector = order => new Order
    {
        Id = order.Id,
        OrderNumber = order.OrderNumber,
        OrderDate = order.OrderDate,
        OrderItems = order.OrderItems.Select(orderItem => new OrderItem
        {
            Id = orderItem.Id,
            BookId = orderItem.BookId,
            OrderId = orderItem.OrderId,
            Quantity = orderItem.Quantity,
            Book = new Book
            {
                Id = orderItem.Book.Id,
                Title = orderItem.Book.Title,
                Author = orderItem.Book.Author,
                Description = orderItem.Book.Description,
                Pages = orderItem.Book.Pages,
                Price = orderItem.Book.Price,
                PublicationDate = orderItem.Book.PublicationDate,
            }
        }).ToList()
    };
    
    public OrderRepository(BookShopDbContext context) : base(context)
    {
    }
    
    public override IQueryable<Order> GetAll()
    {
        return DbSet
            .Include(e => e.OrderItems)
                .ThenInclude(e => e.Book)
            .Select(_selector)
            .AsQueryable();
    }

    public override Task<Order?> GetByIdAsync(int id)
    {
        return DbSet
            .Include(e => e.OrderItems)
            .Select(_selector)
            .FirstOrDefaultAsync(e => e.Id == id);
    }
}