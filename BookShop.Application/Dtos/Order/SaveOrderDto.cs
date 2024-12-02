namespace BookShop.Application.Dtos.Order;

public class SaveOrderDto
{
    public int Id { get; set; }

    public string OrderNumber { get; set; } = string.Empty;
    
    public DateTime OrderDate { get; set; }
}