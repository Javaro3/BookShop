using AutoMapper;
using BookShop.Application.Dtos.OrderItem;
using BookShop.Domains.Entities;

namespace BookShop.Application.Profiles;

public class OrderItemProfile : Profile
{
    public OrderItemProfile()
    {
        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(
                desc => desc.TotalPrice,
                opt => opt
                    .MapFrom(src => src.Book.Price * src.Quantity));
        
        CreateMap<OrderItem, SaveOrderItemDto>();
        CreateMap<SaveOrderItemDto, OrderItem>();
    }
}