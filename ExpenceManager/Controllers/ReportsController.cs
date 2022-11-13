using Microsoft.AspNetCore.Mvc;

namespace ExpenceManager.Controllers
{
    [Route("api/expense-manager/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        [HttpGet("Categories")]
        public async Task<IActionResult> GetCategoryReport(DateTime from, DateTime to)
        {
            return Ok();
        }

        [HttpGet("Shops")]
        public async Task<IActionResult> GetShopReport(DateTime from, DateTime to)
        {
            return Ok();
        }
    }
}