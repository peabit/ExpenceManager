using Microsoft.AspNetCore.Mvc;

namespace ExpenceManager.Controllers
{
    [Route("api/expense-manager/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        [HttpGet("Categories")]
        public async Task<IActionResult> GetCategoriesReport(DateTime from, DateTime to)
        {
            return Ok();
        }

        [HttpGet("Shops")]
        public async Task<IActionResult> GetShopsReport(DateTime from, DateTime to)
        {
            return Ok();
        }
    }
}