using AutoMapper;
using BookShop.Application.Dtos.Order;
using BookShop.Domains.Entities;

namespace BookShop.Application.Profiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderDto>()
            .ForMember(
                desc => desc.TotalPrice,
                opt => opt
                    .MapFrom(src => src.OrderItems.Sum(o => o.Quantity * o.Book.Price)));
        
        CreateMap<Order, SaveOrderDto>();
        CreateMap<SaveOrderDto, Order>();
    }
}