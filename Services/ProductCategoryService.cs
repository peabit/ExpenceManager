using AutoMapper;
using Entities;
using Entities.Exceptions;
using DataTransferObjects;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services;

public sealed class ProductCategoryService : IProductCategoryService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public ProductCategoryService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<ProductCategoryDto>> GetAllAsync()
    {
        var categories = await _repository.ProductCategory.GetAllAsync();

        if (categories.Count == 0)
        {
            throw new ProductCategoriyCollectionNotFoundException();
        }

        return _mapper.Map<IReadOnlyCollection<ProductCategoryDto>>(categories);
    }

    public async Task<ProductCategoryDto> CreateAsync(NewProductCategoryDto category)
    {
        var categoryEntity = _mapper.Map<ProductCategory>(category);
        await _repository.ProductCategory.CreateAsync(categoryEntity);
        return _mapper.Map<ProductCategoryDto>(categoryEntity);
    }

    public async Task UpdateAsync(int id, UpdateProductCategoryDto category)
    {
        if (!_repository.ProductCategory.Contains(p => p.Id == id))
        {
            throw new ProductCategoryNotFoundException(id);
        }

        var categoryEntity = _mapper.Map<ProductCategory>(category);
        categoryEntity.Id = id;

        await _repository.ProductCategory.UpdateAsync(categoryEntity);
    }

    public async Task DeleteAsync(int id)
    {
        var category = await _repository.ProductCategory.GetFirstAsync(с => с.Id == id);

        if (category is null)
        {
            throw new ProductCategoryNotFoundException(id);
        }

        await _repository.ProductCategory.DeleteAsync(category);
    }
}