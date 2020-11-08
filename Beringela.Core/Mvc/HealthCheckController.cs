using Beringela.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Beringela.Core.Mvc
{
    [ApiController]
    [Route("[controller]")]
    public class HealthCheckController : ControllerBase
    {
        [AllowAnonymous, HttpGet]
        public IActionResult Get()
        {
            return Ok(new HealthData());
        }
    }
}
