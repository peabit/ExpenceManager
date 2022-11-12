using Microsoft.AspNetCore.Mvc;

namespace ExpenceManager.Controllers;

[ApiController]
[Route("api/expense-manager/[controller]")]
public class ProductCategoriesController : ControllerBase
{
    [HttpGet]
    public async Task<string> Get( )
    {
        return await Task.FromResult("Categories will be here");
    }

    [HttpPost]
    public async Task Create()
    {

    }

    [HttpDelete("{id}")]
    public async Task Delete()
    {

    }
}