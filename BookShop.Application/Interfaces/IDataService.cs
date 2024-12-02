using BookShop.Application.Dtos;
using BookShop.Application.Dtos.Filter;
using BookShop.Domains.Entities;

namespace BookShop.Application.Interfaces;

/// <summary>
/// Класс для работы с данными
/// </summary>
/// <typeparam name="TModel">сущность</typeparam>
/// <typeparam name="TDto">модель для просмотра</typeparam>
/// <typeparam name="TSaveDto">модель для сохранения</typeparam>
/// <typeparam name="TFilterDto">модель для фильтрации</typeparam>
public interface IDataService<TModel, TDto, TSaveDto, TFilterDto> 
    where TModel : BaseEntity 
    where TFilterDto : FilterRequestDto
{
    /// <summary>
    /// Получить данные с учетом фильтра
    /// </summary>
    /// <param name="filter">фильтр</param>
    /// <returns></returns>
    Task<TransportDto<TDto>> GetFilteredAsync(TFilterDto filter);
    
    /// <summary>
    /// Получить сущность по id
    /// </summary>
    /// <param name="id">уникальные идентификатор</param>
    /// <returns></returns>
    Task<TDto> GetByIdAsync(int id);

    /// <summary>
    /// Сохранить сущность
    /// </summary>
    /// <param name="dto">модель для сохранения</param>
    /// <returns></returns>
    Task<TSaveDto> SaveAsync(TSaveDto dto);
    
    /// <summary>
    /// Удалить сущность
    /// </summary>
    /// <param name="id">уникальные идентификатор</param>
    /// <returns></returns>
    Task DeleteAsync(int id);
}