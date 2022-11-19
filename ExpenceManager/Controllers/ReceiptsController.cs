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

    [HttpGet]
    public async Task<IEnumerable<ReceiptDto>> GetAllAsync()
    {
        var receipts = await _receiptService.GetAllAsync();
        return receipts;
    }

    // TODO: Add GetByPeriod, GetByShopName

    [HttpGet("{receiptId:int}/Positions")]
    public async Task<IEnumerable<ReceiptPositionDto>> GetPositionsAsync(int receiptId)
    {
        var positions = await _receiptService.GetPositionsAsync(receiptId);
        return positions;
    }

    [HttpPost]
    public async Task<ReceiptDto> CreateAsync(NewReceiptDto receipt)
    {
        var createdReceipt = await _receiptService.CreateAsync(receipt);
        return createdReceipt;
    }

    [HttpPost("{id:int}/Positions")]
    public async Task<ReceiptPositionDto> CreatePositionAsync(int receiptId, NewReceiptPositionDto position)
    {
        var createdPosition = await _receiptService.CreatePositionAsync(receiptId, position);
        return createdPosition;
    }

    [HttpPut("{id:int}")]
    public async Task UpdateAsync(int receiptId, UpdateReceiptDto receipt)
        => await _receiptService.UpdateAsync(receiptId, receipt);

    [HttpPut("{receiptId:int}/Position/{positionId:int}")]
    public async Task UpdatePosition(int receiptId, int positionId, UpdateReceiptPositionDto position)
        => await _receiptService.UpdatePositionAsync(receiptId, positionId, position);

    [HttpDelete("{id:int}")]
    public async Task DeleteAsync(int receiptId)
        => await _receiptService.DeleteAsync(receiptId);

    [HttpDelete("{receiptId:int}/Position/{positionId:int}")]
    public async Task DeletePosition(int receiptId, int positionId)
        => await _receiptService.DeletePositionAsync(receiptId, positionId);
}