using Services.Interfaces;
using Entities;
using Repositories.Interfaces;
using DataTransferObjects;

namespace Services;

public sealed class ProductCategoryService : IProductCategoryService
{
    private readonly IRepository<ProductCategory> _repository;

    public ProductCategoryService(IRepository<ProductCategory> repository)
        => _repository = repository;

    public async Task<ProductCategoryDto> CreateAsync(NewProductCategoryDto category)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyCollection<ProductCategoryDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(int id, UpdateProductCategoryDto category)
    {
        throw new NotImplementedException();
    }
}