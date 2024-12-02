using BookShop.Application.Dtos.Order;
using BookShop.Application.Interfaces;
using BookShop.Domains.Constans;
using BookShop.Domains.Entities;

namespace BookShop.Application.Services.Helpers;

/// <summary>
/// Класс для применения фильтров для сущности 'Order'
/// </summary>
public class OrderHelper : IHelper<Order, OrderFilterDto>
{
    public IQueryable<Order> ApplySort(IQueryable<Order> query, OrderFilterDto filter)
    {
        if (filter.SortField is not null)
        {
            switch (filter.SortField.Field)
            {
                case nameof(OrderDto.TotalPrice):
                    query = filter.SortField.Direction == SortDirection.Asc
                        ? query.OrderBy(e => e.OrderItems.Sum(o => o.Book.Price * o.Quantity))
                        : query.OrderByDescending(e => e.OrderItems.Sum(o => o.Book.Price * o.Quantity));
                    filter.SortField = null;
                    break;
            }    
        }

        return query;
    }

    public IQueryable<Order> ApplyFilter(IQueryable<Order> query, OrderFilterDto filter)
    {
        if (!string.IsNullOrEmpty(filter.OrderNumber))
            query = query.Where(e => e.OrderNumber.ToLower().Contains(filter.OrderNumber.ToLower()));
        
        if (filter.OrderDateFrom is not null)
            query = query.Where(e => e.OrderDate >= filter.OrderDateFrom);
        if (filter.OrderDateTo is not null)
            query = query.Where(e => e.OrderDate <= filter.OrderDateTo);
        
        if (filter.TotalPriceFrom is not null)
            query = query.Where(e => e.OrderItems.Sum(o => o.Book.Price * o.Quantity) >= filter.TotalPriceFrom);
        if (filter.TotalPriceTo is not null)
            query = query.Where(e => e.OrderItems.Sum(o => o.Book.Price * o.Quantity) <= filter.TotalPriceTo);

        if (filter.OrderItems.Any())
            query = query.Where(e => filter.OrderItems.All(x => e.OrderItems.Select(d => d.Id).Contains(x)));
        
        return query;
    }
}