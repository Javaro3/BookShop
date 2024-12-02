namespace BookShop.Application.Dtos.Filter;

/// <summary>
/// Объект для сортировки
/// </summary>
public class SortFieldDto
{
    /// <summary>
    /// Поле по которому надо сортировать
    /// </summary>
    public string Field { set; get; } = string.Empty;
    
    /// <summary>
    /// Тип сортировки (по убыванию / по возрастанию)
    /// </summary>
    public string Direction { set; get; } = string.Empty;
}