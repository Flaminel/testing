using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace testing.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestingController : ControllerBase
{
    private readonly ILogger<TestingController> _logger;

    public TestingController(ILogger<TestingController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        await Task.CompletedTask;

        var jsonSettings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented
        };

        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine("############ Start");
        stringBuilder.AppendLine($"Headers: {JsonConvert.SerializeObject(HttpContext.Request.Headers, jsonSettings)}");
        stringBuilder.AppendLine($"Host: {HttpContext.Request.Host}");
        var conn = HttpContext.Connection;
        stringBuilder.AppendLine($"Connection: {conn.LocalIpAddress}:{conn.LocalPort}->{conn.RemoteIpAddress}:{conn.RemotePort}");
        stringBuilder.AppendLine("############ End");

        Console.WriteLine(stringBuilder.ToString());

        return Ok();
    }
}