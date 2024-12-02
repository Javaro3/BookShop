namespace BookShop.Domains.Entities;

/// <summary>
/// Заказ на книгу
/// </summary>
public class OrderItem : BaseEntity
{
    /// <summary>
    /// Номер заказа
    /// </summary>
    public int OrderId { get; set; }

    /// <summary>
    /// Заказ
    /// </summary>
    public Order Order { get; set; } = null!;
    
    /// <summary>
    /// Номер книги
    /// </summary>
    public int BookId { get; set; }
    
    /// <summary>
    /// Книга
    /// </summary>
    public Book Book { get; set; } = null!;
    
    /// <summary>
    /// Количество книг
    /// </summary>
    public int Quantity { get; set; }
}