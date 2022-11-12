using Microsoft.AspNetCore.Mvc;

namespace ExpenceManager.Controllers;

[ApiController]
[Route("api/expense-manager/[controller]")]
public class ReceiptsController : ControllerBase
{
    [HttpGet]
    public async Task<string> GetAll()
    {
        return await Task.FromResult("Receipt list will be here");
    }

    [HttpGet("{id}")]
    public async Task<string> Get()
    {
        return await Task.FromResult("Receipt will be here");
    }

    [HttpPost]
    public async Task Create()
    {

    }

    [HttpDelete("{id}")]
    public async Task Delete()
    {

    }

    [HttpPost("{id}/Position")]
    public async Task CreatePosition()
    {

    }

    [HttpDelete("{id}/Position")]
    public async Task DeletePosition()
    {

    }
}