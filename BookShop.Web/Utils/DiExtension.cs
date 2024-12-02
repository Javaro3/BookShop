using BookShop.Application.Dtos.Book;
using BookShop.Application.Dtos.Order;
using BookShop.Application.Dtos.OrderItem;
using BookShop.Application.Interfaces;
using BookShop.Application.Profiles;
using BookShop.Application.Services.DataServices;
using BookShop.Application.Services.Helpers;
using BookShop.Domains.Entities;
using BookShop.Infrastructure.Interfaces;
using BookShop.Infrastructure.Persistence;
using BookShop.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Web.Utils;

/// <summary>
/// Класс для подключения DI
/// </summary>
public static class DiExtension
{
    /// <summary>
    /// Подключить репозитории
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MySql")!;
        services.AddDbContext<BookShopDbContext>(e => e.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        services.AddScoped<IRepository<Book>, BookRepository>();
        services.AddScoped<IRepository<Order>, OrderRepository>();
        services.AddScoped<IRepository<OrderItem>, OrderItemRepository>();
    }
    
    /// <summary>
    /// Подключить хэлперы
    /// </summary>
    /// <param name="services"></param>
    public static void AddHelpers(this IServiceCollection services)
    {
        services.AddSingleton<IDataSourceHelper, DataSourceHelper>();
        services.AddSingleton<IHelper<Book, BookFilterDto>, BookHelper>();
        services.AddSingleton<IHelper<Order, OrderFilterDto>, OrderHelper>();
        services.AddSingleton<IHelper<OrderItem, OrderItemFilterDto>, OrderItemHelper>();
    }
    
    /// <summary>
    /// Подключить сервисы
    /// </summary>
    /// <param name="services"></param>
    public static void AddDataServices(this IServiceCollection services)
    {
        services.AddScoped<
            IDataService<Book, BookDto, SaveBookDto, BookFilterDto>,
            DataService<Book, BookDto, SaveBookDto, BookFilterDto>>();
        services.AddScoped<
            IDataService<Order, OrderDto, SaveOrderDto, OrderFilterDto>,
            DataService<Order, OrderDto, SaveOrderDto, OrderFilterDto>>();
        services.AddScoped<
            IDataService<OrderItem, OrderItemDto, SaveOrderItemDto, OrderItemFilterDto>,
            DataService<OrderItem, OrderItemDto, SaveOrderItemDto, OrderItemFilterDto>>();
    }
    
    /// <summary>
    /// Подключить мапперы
    /// </summary>
    /// <param name="services"></param>
    public static void AddMappers(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(BookProfile));
        services.AddAutoMapper(typeof(OrderProfile));
        services.AddAutoMapper(typeof(OrderItemProfile));
    }
}