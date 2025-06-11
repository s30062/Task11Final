using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Task11.Services;

namespace src.Task11.Controllers;

[ApiController]
[Authorize]
[Route("api/roles/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;
    private readonly ILogger<RoleController> _log;

    public RoleController(IRoleService roleService, ILogger<RoleController> log)
    {
        _roleService = roleService;
        _log = log;
    }

    [HttpGet("/api/roles")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> RetrieveAll(CancellationToken cancellationToken)
    {
        try
        {
            var roles = await _roleService.GetAllRoles(cancellationToken);
            return Ok(roles);
        }
        catch (Exception exception)
        {
            _log.LogError(exception, "Error retrieving roles: {Message}", exception.Message);
            return StatusCode(500, new { message = "Unable to retrieve roles at this time." });
        }
    }
}