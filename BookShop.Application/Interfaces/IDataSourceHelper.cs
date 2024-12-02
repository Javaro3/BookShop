using AutoMapper;
using BookShop.Application.Dtos;
using BookShop.Application.Dtos.Filter;

namespace BookShop.Application.Interfaces;

/// <summary>
/// Класс для преобразования в DTO
/// </summary>
public interface IDataSourceHelper
{
    /// <summary>
    /// Создать TransportDto
    /// </summary>
    /// <param name="query">запрос</param>
    /// <param name="filter">фильтр</param>
    /// <param name="mapper">маппер</param>
    /// <typeparam name="T">тип сущности</typeparam>
    /// <typeparam name="TDto">тип DTO</typeparam>
    /// <returns></returns>
    Task<TransportDto<TDto>> ApplyDataSource<T, TDto>(IQueryable<T> query, FilterRequestDto filter, IMapper mapper);
}