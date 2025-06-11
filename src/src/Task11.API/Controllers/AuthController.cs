using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using src.Task11.DAL;
using src.Task11.DTO;
using src.Task11.Models;
using src.Task11.Services;
using src.Task11.Services.Tokens;

namespace src.Task11.Controllers;

[ApiController]
[Route("/api/auth/[controller]")]
public class AuthController : ControllerBase
{
    private readonly DeviceEmployeeDbContext _db;
    private readonly ITokenService _tokenGen;
    private readonly PasswordHasher<Account> _hasher;
    private readonly ILogger<AuthController> _log;

    public AuthController(DeviceEmployeeDbContext db, ITokenService tokenGen, ILogger<AuthController> log)
    {
        _db = db;
        _tokenGen = tokenGen;
        _log = log;
        _hasher = new PasswordHasher<Account>();
    }

    [HttpPost("/api/auth")]
    public async Task<IActionResult> Authenticate([FromBody] LoginAccountDto credentials, CancellationToken token)
    {
        try
        {
            var user = await _db.Accounts
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Username == credentials.Login, token);

            if (user is null)
            {
                _log.LogWarning("Authentication failed: user not found");
                return Unauthorized();
            }

            var result = _hasher.VerifyHashedPassword(user, user.Password, credentials.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                _log.LogWarning("Authentication failed: invalid password");
                return Unauthorized();
            }

            var issuedTokens = new
            {
                AccessToken = _tokenGen.GenerateToken(user.Username, user.Role.Name)
            };

            return Ok(issuedTokens);
        }
        catch (Exception ex) when (ex is KeyNotFoundException || ex is InvalidOperationException)
        {
            _log.LogError("Exception during authentication: {Message}", ex.Message);
            return Unauthorized();
        }
    }
}
