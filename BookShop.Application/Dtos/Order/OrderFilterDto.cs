using BookShop.Application.Dtos.Filter;

namespace BookShop.Application.Dtos.Order;

public class OrderFilterDto : FilterRequestDto
{
    public string? OrderNumber { get; set; }
    
    public DateTime? OrderDateFrom { get; set; }

    public DateTime? OrderDateTo { get; set; }
    
    public decimal? TotalPriceFrom { get; set; }
    
    public decimal? TotalPriceTo { get; set; }

    public List<int> OrderItems { get; set; } = [];
}