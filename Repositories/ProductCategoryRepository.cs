using Entities;

namespace Repositories;

public class ProductCategoryRepository : RepositoryBase<ProductCategory>
{
    public ProductCategoryRepository(RepositoryContext context) : base(context) { }
}