using DataTransferObjects;

namespace Services.Interfaces;

public interface IProductCategoryService
{
    Task<ProductCategoryDto> CreateAsync(NewProductCategoryDto category);
    Task<IReadOnlyCollection<ProductCategoryDto>> GetAllAsync();
    Task UpdateAsync(int id, UpdateProductCategoryDto category);
    Task DeleteAsync(int id);
}