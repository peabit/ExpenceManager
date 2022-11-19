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
        => _receiptService = receiptService;
    
    [HttpPost]
    public async Task<ReceiptDto> Create(NewReceiptDto receipt) 
        => await _receiptService.CreateAsync(receipt);

    [HttpPost("{id:int}/Positions")]
    public async Task<ReceiptPositionDto> CreatePosition(int receiptId, NewReceiptPositionDto position)
        => await _receiptService.CreatePositionAsync(receiptId, position);

    [HttpGet]
    public async Task<IEnumerable<ReceiptDto>> GetAll()
        =>await _receiptService.GetAllAsync();

    [HttpGet("{receiptId:int}/Positions")]
    public async Task<IEnumerable<ReceiptPositionDto>> GetPositionsAsync(int receiptId)
        => await _receiptService.GetPositionsAsync(receiptId);

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int receiptId, UpdateReceiptDto receipt)
    {
        return Ok();
    }

    [HttpPut("{receiptId:int}/Position/{positionId:int}")]
    public async Task<IActionResult> UpdatePosition(int receiptId, int positionId, UpdateReceiptPositionDto position)
    {
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int receiptId)
    {
        return Ok();
    }

    [HttpDelete("{receiptId:int}/Position/{positionId:int}")]
    public async Task<IActionResult> DeletePosition(int receiptId, int positionId)
    {
        return Ok();
    }
}