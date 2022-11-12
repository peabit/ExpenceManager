using Microsoft.AspNetCore.Mvc;

namespace ExpenceManager.Controllers;

[Route("api/expense-manager/[controller]")]
[ApiController]
public class ProductCategoriesController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll( )
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Create()
    {
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok();
    }
}