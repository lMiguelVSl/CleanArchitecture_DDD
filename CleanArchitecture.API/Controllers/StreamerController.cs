using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API;

[ApiController]
[Route("api/v1/[controller]")]
public class StreamerController: ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new Streamer());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Streamer streamer)
    {
        return Ok(streamer);
    }
}
