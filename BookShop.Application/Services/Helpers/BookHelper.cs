using BookShop.Application.Dtos.Book;
using BookShop.Application.Interfaces;
using BookShop.Domains.Entities;

namespace BookShop.Application.Services.Helpers;

/// <summary>
/// Класс для применения фильтров для сущности 'Book'
/// </summary>
public class BookHelper : IHelper<Book, BookFilterDto>
{
    public IQueryable<Book> ApplySort(IQueryable<Book> query, BookFilterDto filter)
    {
        return query;
    }

    public IQueryable<Book> ApplyFilter(IQueryable<Book> query, BookFilterDto filter)
    {
        if (!string.IsNullOrEmpty(filter.Title))
            query = query.Where(e => e.Title.ToLower().Contains(filter.Title.ToLower()));
        
        if (!string.IsNullOrEmpty(filter.Author))
            query = query.Where(e => e.Author.ToLower().Contains(filter.Author.ToLower()));
        
        if (!string.IsNullOrEmpty(filter.Description))
            query = query.Where(e => e.Description != null && e.Description.ToLower().Contains(filter.Description.ToLower()));
        
        if (filter.PagesFrom is not null)
            query = query.Where(e => e.Pages >= filter.PagesFrom);
        if (filter.PagesTo is not null)
            query = query.Where(e => e.Pages <= filter.PagesTo);
        
        if (filter.PriceFrom is not null)
            query = query.Where(e => e.Price >= filter.PriceFrom);
        if (filter.PriceTo is not null)
            query = query.Where(e => e.Price <= filter.PriceTo);
        
        if (filter.PriceFrom is not null)
            query = query.Where(e => e.Price >= filter.PriceFrom);
        if (filter.PriceTo is not null)
            query = query.Where(e => e.Price <= filter.PriceTo);
        
        if (filter.PublicationDateFrom is not null)
            query = query.Where(e => e.PublicationDate >= filter.PublicationDateFrom);
        if (filter.PublicationDateTo is not null)
            query = query.Where(e => e.PublicationDate <= filter.PublicationDateTo);
        
        if (filter.OrderItems.Any())
            query = query.Where(e => filter.OrderItems.All(x => e.OrderItems.Select(d => d.Id).Contains(x)));

        return query;
    }
}