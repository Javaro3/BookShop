using AutoMapper;
using BookShop.Application.Dtos;
using BookShop.Application.Dtos.Filter;
using BookShop.Application.Interfaces;
using BookShop.Domains.Entities;
using BookShop.Infrastructure.Interfaces;

namespace BookShop.Application.Services.DataServices;

/// <summary>
/// Базовый DataService
/// </summary>
/// <typeparam name="TModel"></typeparam>
/// <typeparam name="TDto"></typeparam>
/// <typeparam name="TSaveDto"></typeparam>
/// <typeparam name="TFilterDto"></typeparam>
public class DataService<TModel, TDto, TSaveDto, TFilterDto> : IDataService<TModel, TDto, TSaveDto, TFilterDto> 
    where TModel : BaseEntity
    where TFilterDto : FilterRequestDto
{
    private readonly IRepository<TModel> _repository;
    private readonly IDataSourceHelper _dataSourceHelper;
    private readonly IHelper<TModel, TFilterDto> _helper;
    private readonly IMapper _mapper;
    
    public DataService(
        IRepository<TModel> repository,
        IDataSourceHelper dataSourceHelper,
        IHelper<TModel, TFilterDto> helper,
        IMapper mapper)
    {
        _repository = repository;
        _dataSourceHelper = dataSourceHelper;
        _helper = helper;
        _mapper = mapper;
    }
    
    public async Task<TransportDto<TDto>> GetFilteredAsync(TFilterDto filter)
    {
        var query = _repository.GetAll();
        query = _helper.ApplyFilter(query, filter);
        query = _helper.ApplySort(query, filter);
        
        var transportDto = await _dataSourceHelper.ApplyDataSource<TModel, TDto>(query, filter, _mapper);
        return transportDto;
    }

    public async Task<TDto> GetByIdAsync(int id)
    {
        var model = await _repository.GetByIdAsync(id);
        var dto = _mapper.Map<TDto>(model);
        return dto;
    }

    public async Task<TSaveDto> SaveAsync(TSaveDto dto)
    {
        var model = _mapper.Map<TModel>(dto);
        if (model.Id == 0)
            await _repository.AddAsync(model);
        else
            await _repository.UpdateAsync(model);

        var savedDto = _mapper.Map<TSaveDto>(model);
        return savedDto;
    }

    public async Task DeleteAsync(int id)
    {
        var model = await _repository.GetByIdAsync(id);
        if (model is null)
            throw new ArgumentException($"Entity with id - {id} is not exists");
                
        await _repository.DeleteAsync(model);
    }
}