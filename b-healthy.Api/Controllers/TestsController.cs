
using b_healthy.Data;
using b_healthy.FitnessTesting;
using Beringela.Api.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Beringela.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TestsController: ControllerBase
{
    [HttpPost]
    public IActionResult EvaluateRestingHeartRate([FromBody]RestingHeartRateDto restringRestingHeartRateDto)
    {
        if (!restringRestingHeartRateDto.Validate())
        {
            return BadRequest();
        }

        var test = new RestingHeartRate();
        
        var classification = test.Compute(restringRestingHeartRateDto.Gender, restringRestingHeartRateDto.Age,
            restringRestingHeartRateDto.Rate);
        
        var returnValue =  new TestResult() { Classification = classification };
        
        return Ok(returnValue);
    }
}