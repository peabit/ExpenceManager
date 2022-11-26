using Microsoft.AspNetCore.Mvc;
using DataTransferObjects;
using Services.Interfaces;

namespace ExpenceManager.Controllers;

[Route("api/expense-manager/[controller]")]
[ApiController]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class ReceiptsController : ControllerBase
{
    private readonly IReceiptService _receiptService;

    public ReceiptsController(IReceiptService receiptService)
        => _receiptService = receiptService;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IEnumerable<ReceiptDto>> GetAllAsync()
    {
        var receipts = await _receiptService.GetAllAsync();
        return receipts;
    }

    [HttpGet("{from:datetime}&{to:datetime}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IEnumerable<ReceiptDto>> GetAsync(DateTime from, DateTime to)
    {
        var receipts = await _receiptService.GetAsync(from, to);
        return receipts;
    }

    [HttpGet("{shopName}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IEnumerable<ReceiptDto>> GetAsync(string shopName)
    {
        var receipts = await _receiptService.GetAsync(shopName);
        return receipts;
    }

    [HttpGet("{receiptId:int}/Positions")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IEnumerable<ReceiptPositionDto>> GetPositionsAsync(int receiptId)
    {
        var positions = await _receiptService.GetPositionsAsync(receiptId);
        return positions;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ReceiptDto> CreateAsync(NewReceiptDto receipt)
    {
        var createdReceipt = await _receiptService.CreateAsync(receipt);
        return createdReceipt;
    }

    [HttpPost("{receiptId:int}/Positions")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ReceiptPositionDto> CreatePositionAsync(int receiptId, NewReceiptPositionDto position)
    {
        var createdPosition = await _receiptService.CreatePositionAsync(receiptId, position);
        return createdPosition;
    }

    [HttpPut("{receiptId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task UpdateAsync(int receiptId, UpdateReceiptDto receipt)
        => await _receiptService.UpdateAsync(receiptId, receipt);

    [HttpPut("{receiptId:int}/Position/{positionId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task UpdatePositionAsync(int receiptId, int positionId, UpdateReceiptPositionDto position)
        => await _receiptService.UpdatePositionAsync(receiptId, positionId, position);

    [HttpDelete("{receiptId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task DeleteAsync(int receiptId)
        => await _receiptService.DeleteAsync(receiptId);

    [HttpDelete("{receiptId:int}/Position/{positionId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task DeletePositionAsync(int receiptId, int positionId)
        => await _receiptService.DeletePositionAsync(receiptId, positionId);
}