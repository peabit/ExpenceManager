using Microsoft.AspNetCore.Mvc;
using DataTransferObjects;
using Services.Interfaces;

namespace ExpenceManager.Controllers;

[Route("api/expense-manager/[controller]")]
[ApiController]
public class ReceiptsController : ControllerBase
{
    private readonly IReceiptService _receiptService;

    public ReceiptsController(IReceiptService receiptService)
    {
        _receiptService = receiptService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(NewReceiptDto receipt) {
        await _receiptService.CreateAsync(receipt);
        return Ok();
    } 

    [HttpPost("{id:int}/Position")]
    public async Task<IActionResult> CreatePosition(int receiptId, NewReceiptPositionDto position)
    {
        return Ok();
    }

    [HttpGet]
    public async Task<IEnumerable<ReceiptDto>> GetAll()
        =>await _receiptService.GetAllAsync();

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