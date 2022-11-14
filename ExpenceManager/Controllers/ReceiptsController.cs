using Microsoft.AspNetCore.Mvc;
using DataTransferObjects;

namespace ExpenceManager.Controllers;

[Route("api/expense-manager/[controller]")]
[ApiController]
public class ReceiptsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(NewReceiptDto receipt)
    {
        return Ok();
    }

    [HttpPost("{id:int}/Position")]
    public async Task<IActionResult> CreatePosition(int receiptId, NewReceiptPositionDto position)
    {
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        throw new Exception("Super critical error!!!");
        return Ok();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateReceiptDto receipt)
    {
        return Ok();
    }

    [HttpPut("{receiptId:int}/Position/{positionId:int}")]
    public async Task<IActionResult> UpdatePosition(int receiptId, int positionId, UpdateReceiptPositionDto position)
    {
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok();
    }

    [HttpDelete("{receiptId:int}/Position/{positionId:int}")]
    public async Task<IActionResult> DeletePosition(int receiptId, int positionId)
    {
        return Ok();
    }
}