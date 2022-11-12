using Microsoft.AspNetCore.Mvc;

namespace ExpenceManager.Controllers;

[ApiController]
[Route("api/expense-manager/[controller]")]
public class UnitsOfMeasurementController : ControllerBase
{
    [HttpGet]
    public async Task<string> Get()
    {
        return await Task.FromResult("Units of measurement will be here");
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
