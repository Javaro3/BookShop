using BookShop.Domains.Entities;

namespace BookShop.Infrastructure.Interfaces;

/// <summary>
/// Интерфейс репозитория
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T> where T : BaseEntity
{
    /// <summary>
    /// Получить все сущности
    /// </summary>
    /// <returns></returns>
    IQueryable<T> GetAll();

    /// <summary>
    /// Получить сущность по Id
    /// </summary>
    /// <param name="id">уникальный идентификатор сущности</param>
    /// <returns></returns>
    Task<T?> GetByIdAsync(int id);

    /// <summary>
    /// Добавление сущности
    /// </summary>
    /// <param name="entity">сущность</param>
    /// <returns></returns>
    Task AddAsync(T entity);

    /// <summary>
    /// Обновление сущности
    /// </summary>
    /// <param name="entity">сущность</param>
    /// <returns></returns>
    Task UpdateAsync(T entity);

    /// <summary>
    /// Удаление сущности
    /// </summary>
    /// <param name="entity">сущность</param>
    /// <returns></returns>
    Task DeleteAsync(T entity);
}