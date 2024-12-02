using BookShop.Application.Dtos.OrderItem;
using BookShop.Application.Interfaces;
using BookShop.Domains.Constans;
using BookShop.Domains.Entities;

namespace BookShop.Application.Services.Helpers;

/// <summary>
/// Класс для применения фильтров для сущности 'OrderItem'
/// </summary>
public class OrderItemHelper : IHelper<OrderItem, OrderItemFilterDto>
{
    public IQueryable<OrderItem> ApplySort(IQueryable<OrderItem> query, OrderItemFilterDto filter)
    {
        if (filter.SortField is not null)
        {
            switch (filter.SortField.Field)
            {
                case nameof(OrderItemDto.TotalPrice):
                    query = filter.SortField.Direction == SortDirection.Asc
                        ? query.OrderBy(e => e.Book.Price * e.Quantity)
                        : query.OrderByDescending(e => e.Book.Price * e.Quantity);
                    filter.SortField = null;
                    break;
            }    
        }

        return query;
    }

    public IQueryable<OrderItem> ApplyFilter(IQueryable<OrderItem> query, OrderItemFilterDto filter)
    {
        if (filter.Books.Any())
            query = query.Where(e => filter.Books.Contains(e.BookId));

        if (filter.Orders.Any())
            query = query.Where(e => filter.Orders.Contains(e.OrderId));

        if (filter.QuantityFrom is not null)
            query = query.Where(e => e.Quantity >= filter.QuantityFrom);
        if (filter.QuantityTo is not null)
            query = query.Where(e => e.Quantity <= filter.QuantityTo);
        
        if (filter.TotalPriceFrom is not null)
            query = query.Where(e => e.Book.Price * e.Quantity >= filter.TotalPriceFrom);
        if (filter.TotalPriceTo is not null)
            query = query.Where(e => e.Book.Price * e.Quantity <= filter.TotalPriceTo);
        
        return query;
    }
}