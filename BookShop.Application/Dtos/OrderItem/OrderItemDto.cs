using BookShop.Application.Dtos.Book;
using BookShop.Application.Dtos.Order;

namespace BookShop.Application.Dtos.OrderItem;

public class OrderItemDto
{
    public int Id { get; set; }

    public OrderDto Order { get; set; } = null!;

    public BookDto Book { get; set; } = null!;
    
    public int Quantity { get; set; }
    
    public decimal TotalPrice { get; set; }
}