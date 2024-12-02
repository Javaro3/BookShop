using BookShop.Application.Dtos.Filter;

namespace BookShop.Application.Dtos.Book;

public class BookFilterDto : FilterRequestDto
{
    public string? Title { get; set; }
    
    public string? Author { get; set; }
    
    public string? Description { get; set; }
    
    public int? PagesFrom { get; set; }
    
    public int? PagesTo { get; set; }
    
    public decimal? PriceFrom { get; set; }

    public decimal? PriceTo { get; set; }

    public DateTime? PublicationDateFrom { get; set; }

    public DateTime? PublicationDateTo { get; set; }

    public List<int> OrderItems { get; set; } = [];
}