using System.Linq.Expressions;
using BookShop.Domains.Entities;
using BookShop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.Repositories;

public class BookRepository : Repository<Book>
{
    private readonly Expression<Func<Book, Book>> _selector = book => new Book
    {
        Id = book.Id,
        Title = book.Title,
        Author = book.Author,
        Description = book.Description,
        Pages = book.Pages,
        Price = book.Price,
        PublicationDate = book.PublicationDate,
        OrderItems = book.OrderItems.Select(orderItem => new OrderItem
        {
            Id = orderItem.Id,
            BookId = orderItem.BookId,
            OrderId = orderItem.OrderId,
            Quantity = orderItem.Quantity,
        }).ToList()
    };
    
    public BookRepository(BookShopDbContext context) : base(context)
    {
    }
    
    public override IQueryable<Book> GetAll()
    {
        return DbSet
            .Include(e => e.OrderItems)
            .Select(_selector)
            .AsQueryable();
    }

    public override Task<Book?> GetByIdAsync(int id)
    {
        return DbSet
            .Include(e => e.OrderItems)
            .Select(_selector)
            .FirstOrDefaultAsync(e => e.Id == id);
    }
}