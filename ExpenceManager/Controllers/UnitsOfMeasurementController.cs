using Microsoft.AspNetCore.Mvc;
using DataTransferObjects;
using Services.Interfaces;

namespace ExpenceManager.Controllers;

[Route("api/expense-manager/[controller]")]
[ApiController]
public class UnitsOfMeasurementController : ControllerBase
{
    private readonly IUnitOfMeasurementService _unitOfMeasurementService;

    public UnitsOfMeasurementController(IUnitOfMeasurementService unitOfMeasurementService)
        => _unitOfMeasurementService = unitOfMeasurementService;    

    [HttpGet]
    public async Task<IReadOnlyCollection<UnitOfMeasurementDto>> GetAllAsync()
    {
        var unitsOfMeasurement = await _unitOfMeasurementService.GetAllAsync();
        return unitsOfMeasurement;
    }

    [HttpPost]
    public async Task<UnitOfMeasurementDto> CreateAsync(NewUnitOfMeasurementDto unitOfMeasurement)
    {
        var newUnitOfMeasurement = await _unitOfMeasurementService.CreateAsync(unitOfMeasurement);
        return newUnitOfMeasurement;
    }

    [HttpPut("{id:int}")]
    public async Task UpdateAsync(int id, UpdateUnitOfMeasurementDto unitOfMeasurement)
        => await _unitOfMeasurementService.UpdateAsync(id, unitOfMeasurement);


    [HttpDelete("{id:int}")]
    public async Task DeleteAsync(int id)
        => await _unitOfMeasurementService.DeleteAsync(id);
}