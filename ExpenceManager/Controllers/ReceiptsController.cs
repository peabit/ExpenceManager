using Microsoft.AspNetCore.Mvc;
using DataTransferObjects;

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
    public async Task<IActionResult> Create(NewReceiptDto receipt)
    {
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok();
    }

    [HttpPost("{id:int}/Position")]
    public async Task<IActionResult> CreatePosition(int receiptId, NewReceiptPositionDto position)
    {
        return Ok();
    }

    [HttpDelete("{receiptId:int}/Position/{positionId:int}")]
    public async Task<IActionResult> DeletePosition(int receiptId, int positionId)
    {
        return Ok();
    }
}