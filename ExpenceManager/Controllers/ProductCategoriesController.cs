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

    [HttpPut("{сategorId:int}")]
    public async Task UpdateAsync(int сategorId, UpdateProductCategoryDto categoryDto)
        => await _сategoryService.UpdateAsync(сategorId, categoryDto);

    [HttpDelete("{сategorId:int}")]
    public async Task DeleteAsync(int сategorId)
        => await _сategoryService.DeleteAsync(сategorId);
}