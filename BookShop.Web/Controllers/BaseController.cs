using BookShop.Application.Dtos.Filter;
using BookShop.Application.Interfaces;
using BookShop.Domains.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Web.Controllers;

public abstract class BaseController<TEntity, TDto, TSaveDto, TFilterDto> : Controller
    where TEntity : BaseEntity
    where TFilterDto : FilterRequestDto
{
    protected readonly IDataService<TEntity, TDto, TSaveDto, TFilterDto> _dataService;

    public BaseController(IDataService<TEntity, TDto, TSaveDto, TFilterDto> dataService)
    {
        _dataService = dataService;
    }

    [HttpGet]
    public async Task<IResult> Get([FromQuery] TFilterDto filter)
    {
        var data = await _dataService.GetFilteredAsync(filter);
        return Results.Json(data);
    }

    [HttpGet("{id:int}")]
    public async Task<IResult> Get(int id)
    {
        var data = await _dataService.GetByIdAsync(id);
        return Results.Json(data);
    }

    [HttpPost]
    public async Task<IResult> Add([FromBody] TSaveDto dto)
    {
        var newDto = await _dataService.SaveAsync(dto);
        return Results.Json(newDto);
    }

    [HttpPut]
    public async Task<IResult> Update([FromBody] TSaveDto dto)
    {
        var updatedDto = await _dataService.SaveAsync(dto);
        return Results.Json(updatedDto);
    }

    [HttpDelete]
    public async Task<IResult> Delete([FromQuery] int id)
    {
        await _dataService.DeleteAsync(id);
        return Results.Ok();
    }
}