using BookShop.Application.Dtos.OrderItem;

namespace BookShop.Application.Dtos.Book;

public class BookDto
{
    public int Id { get; set; }
    
    public string Title { get; set; } = string.Empty;
    
    public string Author { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int Pages { get; set; }
    
    public decimal Price { get; set; }
    
    public DateTime? PublicationDate { get; set; }

    public ICollection<OrderItemDto> OrderItems { get; set; } = [];
}