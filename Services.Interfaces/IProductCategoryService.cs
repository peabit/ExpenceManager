using DataTransferObjects;

namespace Services.Interfaces;

public interface IProductCategoryService
{
    Task<ProductCategoryDto> Create(NewProductCategoryDto category);
    Task<IReadOnlyCollection<ProductCategoryDto>> GetAll();
    Task Update(UpdateProductCategoryDto category);
    Task Delete(int id);
}