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

    public Task<ProductCategoryDto> Create(NewProductCategoryDto category)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<ProductCategoryDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Update(int id, UpdateProductCategoryDto category)
    {
        throw new NotImplementedException();
    }
}