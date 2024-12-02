using BookShop.Application.Dtos.OrderItem;

namespace BookShop.Application.Dtos.Order;

public class OrderDto
{
    public int Id { get; set; }
    
    public string OrderNumber { get; set; } = string.Empty;
    
    public DateTime OrderDate { get; set; }
    
    public decimal TotalPrice { get; set; }

    public ICollection<OrderItemDto> OrderItems { get; set; } = [];
}