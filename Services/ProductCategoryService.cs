using AutoMapper;
using Services.Interfaces;
using Entities;
using Repositories.Interfaces;
using DataTransferObjects;

namespace Services;

public sealed class ProductCategoryService : IProductCategoryService
{
    private readonly IRepository<ProductCategory> _repository;
    private readonly IMapper _mapper;

    public ProductCategoryService(IRepository<ProductCategory> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<ProductCategoryDto>> GetAllAsync()
    {
        var categories = await _repository.GetAllAsync();

        if (categories is null)
        {
            // TODO: Exceiption
        }

        return _mapper.Map<IReadOnlyCollection<ProductCategoryDto>>(categories);
    }

    public async Task<ProductCategoryDto> CreateAsync(NewProductCategoryDto category)
    {
        var categoryEntity = _mapper.Map<ProductCategory>(category);
        await _repository.CreateAsync(categoryEntity);
        return _mapper.Map<ProductCategoryDto>(categoryEntity);
    }

    public async Task UpdateAsync(int categoryId, UpdateProductCategoryDto category)
    {
        ThrowIfReceiptNotExist(categoryId);

        var categoryEntity = _mapper.Map<ProductCategory>(category);
        categoryEntity.Id = categoryId;

        await _repository.UpdateAsync(categoryEntity);
    }

    public async Task DeleteAsync(int categoryId)
    {
        ThrowIfReceiptNotExist(categoryId);
        await _repository.DeleteAsync(categoryId);
    }

    private void ThrowIfReceiptNotExist(int categoryId)
    {

    }
}