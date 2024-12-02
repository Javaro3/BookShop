using BookShop.Application.Dtos.Order;
using BookShop.Application.Interfaces;
using BookShop.Domains.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : BaseController<Order, OrderDto, SaveOrderDto, OrderFilterDto>
{
    public OrderController(IDataService<Order, OrderDto, SaveOrderDto, OrderFilterDto> orderDataService) : base(orderDataService)
    {
    }
}