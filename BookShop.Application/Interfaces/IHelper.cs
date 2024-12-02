using BookShop.Application.Dtos.Filter;
using BookShop.Domains.Entities;

namespace BookShop.Application.Interfaces;

/// <summary>
/// Класс для соротировки и фильтрации
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TFilter"></typeparam>
public interface IHelper<T, TFilter>
    where T : BaseEntity
    where TFilter : FilterRequestDto
{
    /// <summary>
    /// Применить сортировку
    /// </summary>
    /// <param name="query">запрос</param>
    /// <param name="filter">фильтр</param>
    /// <returns></returns>
    IQueryable<T> ApplySort(IQueryable<T> query, TFilter filter);
    
    /// <summary>
    /// Применить фильтры
    /// </summary>
    /// <param name="query">запрос</param>
    /// <param name="filter">фильтр</param>
    /// <returns></returns>
    IQueryable<T> ApplyFilter(IQueryable<T> query, TFilter filter);
}