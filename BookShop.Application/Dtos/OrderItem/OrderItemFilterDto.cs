using BookShop.Application.Dtos.Filter;

namespace BookShop.Application.Dtos.OrderItem;

public class OrderItemFilterDto : FilterRequestDto
{
    public List<int> Orders { get; set; } = [];

    public List<int> Books { get; set; } = [];
    
    public int? QuantityFrom { get; set; }
    
    public int? QuantityTo { get; set; }
    
    public decimal? TotalPriceFrom { get; set; }
    
    public decimal? TotalPriceTo { get; set; }
}