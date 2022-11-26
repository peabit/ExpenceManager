using Microsoft.AspNetCore.Mvc;
using DataTransferObjects;
using Services.Interfaces;

namespace ExpenceManager.Controllers;

[Route("api/expense-manager/[controller]")]
[ApiController]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class UnitsOfMeasurementController : ControllerBase
{
    private readonly IUnitOfMeasurementService _unitOfMeasurementService;

    public UnitsOfMeasurementController(IUnitOfMeasurementService unitOfMeasurementService)
        => _unitOfMeasurementService = unitOfMeasurementService;    

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IReadOnlyCollection<UnitOfMeasurementDto>> GetAllAsync()
    {
        var unitsOfMeasurement = await _unitOfMeasurementService.GetAllAsync();
        return unitsOfMeasurement;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<UnitOfMeasurementDto> CreateAsync(NewUnitOfMeasurementDto unitOfMeasurement)
    {
        var newUnitOfMeasurement = await _unitOfMeasurementService.CreateAsync(unitOfMeasurement);
        return newUnitOfMeasurement;
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task UpdateAsync(int id, UpdateUnitOfMeasurementDto unitOfMeasurement)
        => await _unitOfMeasurementService.UpdateAsync(id, unitOfMeasurement);


    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task DeleteAsync(int id)
        => await _unitOfMeasurementService.DeleteAsync(id);
}