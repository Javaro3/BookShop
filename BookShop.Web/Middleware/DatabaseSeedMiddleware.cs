using BookShop.Domains.Entities;
using BookShop.Infrastructure.Interfaces;
using BookShop.Infrastructure.Persistence;

namespace BookShop.Web.Middleware;

public class DatabaseSeedMiddleware
{
    private readonly RequestDelegate _next;
    private readonly Random _random = new();
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public DatabaseSeedMiddleware(
        RequestDelegate next,
        IServiceScopeFactory serviceScopeFactory)
    {
        _next = next;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<BookShopDbContext>();
        var bookRepository = scope.ServiceProvider.GetRequiredService<IRepository<Book>>();
        var orderRepository = scope.ServiceProvider.GetRequiredService<IRepository<Order>>();
        var orderItemRepository = scope.ServiceProvider.GetRequiredService<IRepository<OrderItem>>();
        
        await dbContext.Database.EnsureCreatedAsync();
        
        if (!bookRepository.GetAll().Any())
            await SeedBooks(bookRepository);
        if (!orderRepository.GetAll().Any())
            await SeedOrders(orderRepository);
        if (!orderItemRepository.GetAll().Any())
            await SeedOrderItems(orderItemRepository);

        await _next(httpContext);
    }

    private async Task SeedBooks(IRepository<Book> repository)
    {
        for (var i = 0; i < 100; i++)
        {
            var book = new Book
            {
                Title = $"Book {i}",
                Author = $"Author {i}",
                Description = $"Description {i}",
                Pages = _random.Next(5, 1000),
                Price = _random.Next(5, 100),
                PublicationDate = new DateTime(_random.Next(1700, 2024), _random.Next(1, 13), _random.Next(1, 20)).ToUniversalTime()
            };
            await repository.AddAsync(book);
        }
    }
    
    private async Task SeedOrders(IRepository<Order> repository)
    {
        for (var i = 0; i < 100; i++)
        {
            var order = new Order
            {
                OrderNumber = $"{Guid.NewGuid().ToString()[..8]}",
                OrderDate = new DateTime(_random.Next(2000, 2024), _random.Next(1, 13), _random.Next(1, 20)).ToUniversalTime()
            };
            await repository.AddAsync(order);
        }
    }
    
    private async Task SeedOrderItems(IRepository<OrderItem> repository)
    {
        for (var i = 0; i < 100; i++)
        {
            var orderItem = new OrderItem
            {
                OrderId = _random.Next(1, 101),
                BookId = _random.Next(1, 101),
                Quantity = _random.Next(1, 20)
            };
            await repository.AddAsync(orderItem);
        }
    }
}