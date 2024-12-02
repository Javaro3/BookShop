using BookShop.Application.Dtos.OrderItem;
using BookShop.Application.Interfaces;
using BookShop.Domains.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderItemController : BaseController<OrderItem, OrderItemDto, SaveOrderItemDto, OrderItemFilterDto>
{
    public OrderItemController(IDataService<OrderItem, OrderItemDto, SaveOrderItemDto, OrderItemFilterDto> dataService) : base(dataService)
    {
    }
}