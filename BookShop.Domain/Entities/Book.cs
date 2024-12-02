namespace BookShop.Domains.Entities;

/// <summary>
/// Сущность книги
/// </summary>
public class Book : BaseEntity
{
    /// <summary>
    /// Название книги
    /// </summary>
    public string Title { get; set; } = string.Empty;
    
    /// <summary>
    /// Автор книги
    /// </summary>
    public string Author { get; set; } = string.Empty;

    /// <summary>
    /// Описание книги
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Количество страниц
    /// </summary>
    public int Pages { get; set; }
    
    /// <summary>
    /// Цена книги
    /// </summary>
    public decimal Price { get; set; }
    
    /// <summary>
    /// Дата публикации
    /// </summary>
    public DateTime? PublicationDate { get; set; }

    /// <summary>
    /// Заказы
    /// </summary>
    public ICollection<OrderItem> OrderItems { get; set; } = [];
}