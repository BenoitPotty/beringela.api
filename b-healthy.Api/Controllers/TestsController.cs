
using Microsoft.AspNetCore.Mvc;

namespace Beringela.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TestsController: ControllerBase
{
    [HttpGet]
    public object GetTests()
    {
        return new { Test = "Test" };
    }
}