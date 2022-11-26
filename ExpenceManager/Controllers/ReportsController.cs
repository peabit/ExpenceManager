using Microsoft.AspNetCore.Mvc;

namespace ExpenceManager.Controllers
{
    [Route("api/expense-manager/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class ReportsController : ControllerBase
    {
        [HttpGet("Categories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategoryReport(DateTime from, DateTime to)
        {
            return Ok();
        }

        [HttpGet("Shops")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetShopReport(DateTime from, DateTime to)
        {
            return Ok();
        }
    }
}