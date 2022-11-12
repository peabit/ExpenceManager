using Microsoft.AspNetCore.Mvc;

namespace ExpenceManager.Controllers;

[Route("api/expense-manager/[controller]")]
[ApiController]
public class ReceiptsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
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

    [HttpPost("{id}/Position")]
    public async Task<IActionResult> CreatePosition()
    {
        return Ok();
    }

    [HttpDelete("{receiptId:int}/Position/{positionId:int}")]
    public async Task<IActionResult> DeletePosition(int receiptId, int positionId)
    {
        return Ok();
    }
}