using BackgroundServices.Core;
using Microsoft.AspNetCore.Mvc;

namespace BackgroundServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet("ping")]
        public IActionResult Get()
        {
            return Ok(FriendlyTimeGenerator.GetCurrentTime());
        }
    }
}
