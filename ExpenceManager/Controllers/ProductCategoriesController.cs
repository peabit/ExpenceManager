using Microsoft.AspNetCore.Mvc;
using DataTransferObjects;
using Services.Interfaces;

namespace ExpenceManager.Controllers;

[Route("api/expense-manager/[controller]")]
[ApiController]
public class ProductCategoriesController : ControllerBase
{
    private readonly IProductCategoryService _сategoryService;

    public ProductCategoriesController(IProductCategoryService сategoryService)
        => _сategoryService = сategoryService;

    [HttpGet]
    public async Task<IReadOnlyCollection<ProductCategoryDto>> GetAllAsync()
    {
        var categories = await _сategoryService.GetAllAsync();
        return categories;
    }

    [HttpPost]
    public async Task<ProductCategoryDto> CreateAsync(NewProductCategoryDto category)
    {
        var newCategory = await _сategoryService.CreateAsync(category);
        return newCategory;
    }

    [HttpPut("{id:int}")]
    public async Task UpdateAsync(int id, UpdateProductCategoryDto categoryDto)
        => await _сategoryService.UpdateAsync(id, categoryDto);

    [HttpDelete("{id:int}")]
    public async Task DeleteAsync(int id)
        => await _сategoryService.DeleteAsync(id);
}