namespace BookShop.Application.Dtos;

/// <summary>
/// Объект для передачи данных о сущности
/// </summary>
/// <typeparam name="T">сущность</typeparam>
public class TransportDto<T>
{
    /// <summary>
    /// Список сущностей
    /// </summary>
    public List<T> Data { get; set; } = [];

    /// <summary>
    /// Суммарное количество элементов
    /// </summary>
    public int TotalCount { get; set; }
}