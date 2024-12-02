namespace BookShop.Domains.Entities;

/// <summary>
/// Заказ
/// </summary>
public class Order : BaseEntity
{
    /// <summary>
    /// Номер заказа
    /// </summary>
    public string OrderNumber { get; set; } = string.Empty;
    
    /// <summary>
    /// Дата заказа
    /// </summary>
    public DateTime OrderDate { get; set; }

    /// <summary>
    /// Список книг и их количество
    /// </summary>
    public ICollection<OrderItem> OrderItems { get; set; } = [];
}