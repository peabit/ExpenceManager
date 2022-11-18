using Services.Interfaces;
using Entities;
using Repositories.Interfaces;
using DataTransferObjects;

namespace Services;

public class ProductCategoryService : ServiceBase<ProductCategory>, IProductCategoryService
{
    public ProductCategoryService(IRepository<ProductCategory> repository) : base(repository) { }

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