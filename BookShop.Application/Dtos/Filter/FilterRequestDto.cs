namespace BookShop.Application.Dtos.Filter;

/// <summary>
/// Объект для пагинации
/// </summary>
public class FilterRequestDto
{
    /// <summary>
    /// Номер страницы
    /// </summary>
    public int PageNumber { get; set; }
    
    /// <summary>
    /// Размер страницы
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Сортировка
    /// </summary>
    public SortFieldDto? SortField { get; set; }
}