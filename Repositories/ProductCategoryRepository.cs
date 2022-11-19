using Entities;

namespace Repositories;

public sealed class ProductCategoryRepository : RepositoryBase<ProductCategory>
{
    public ProductCategoryRepository(RepositoryContext context) : base(context) { }
}