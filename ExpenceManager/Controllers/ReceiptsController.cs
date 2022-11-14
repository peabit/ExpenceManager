using Microsoft.AspNetCore.Mvc;
using Repositories;
using DataTransferObjects;
using Entities;

namespace ExpenceManager.Controllers;

[Route("api/expense-manager/[controller]")]
[ApiController]
public class ReceiptsController : ControllerBase
{
    private readonly RepositoryContext _context;

    public ReceiptsController(RepositoryContext context)
    {
        _context = context;
    }

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
        var receipt = new Receipt( )
        {
            ShopName = "Пятёрочка",
            DateTime = DateTime.UtcNow
        };

        receipt.Positions.Add(
            new ReceiptPosition()
            {
                ProductName = "Молоко"
            }
        );

        _context.Receipts.Add(receipt);
        await _context.SaveChangesAsync(); 

        //throw new Exception("Super critical error!!!");
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