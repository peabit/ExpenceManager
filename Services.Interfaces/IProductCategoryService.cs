using DataTransferObjects;

namespace Services.Interfaces;

public interface IProductCategoryService
{
    Task<IReadOnlyCollection<ProductCategoryDto>> GetAllAsync();
    Task<ProductCategoryDto> CreateAsync(NewProductCategoryDto category);
    Task UpdateAsync(int categoryId, UpdateProductCategoryDto category);
    Task DeleteAsync(int categoryId);
}