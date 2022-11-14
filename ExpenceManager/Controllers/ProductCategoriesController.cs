using Microsoft.AspNetCore.Mvc;
using DataTransferObjects;

namespace ExpenceManager.Controllers;

[Route("api/expense-manager/[controller]")]
[ApiController]
public class ProductCategoriesController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(NewProductCategoryDto product)
    {
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateProductCategoryDto categoryDto)
    {
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok();
    }
}