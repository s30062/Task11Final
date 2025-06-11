using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Task11.Services;

namespace src.Task11.Controllers;

[ApiController]
[Authorize]
[Route("api/positions/[controller]")]
public class PositionController : ControllerBase
{
    private readonly IPositionService _positionService;
    private readonly ILogger<PositionController> _log;

    public PositionController(IPositionService positionService, ILogger<PositionController> log)
    {
        _positionService = positionService;
        _log = log;
    }

    [HttpGet("/api/positions")]
    public async Task<IActionResult> FetchAll(CancellationToken cancellationToken)
    {
        try
        {
            var positions = await _positionService.GetAllPositions(cancellationToken);
            return Ok(positions);
        }
        catch (Exception error)
        {
            _log.LogError(error, "Failed to retrieve positions: {Error}", error.Message);
            return StatusCode(500, new { message = "An error occurred while retrieving positions." });
        }
    }
}