using Microsoft.AspNetCore.Mvc;
using TestDito.Application.DTOs;
using TestDito.Application.Interfaces.Services;

namespace TestDito.API.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
	private readonly ILogger<UserController> _logger;
	private readonly IAuthService _authService;

	public AuthController(ILogger<UserController> logger, IAuthService authService)
	{
		_logger = logger;
		_authService = authService;
	}

	[HttpPost("login")]
	public async Task<IActionResult> Login([FromBody] LoginDto login)
	{
		_logger.LogInformation("Inicio: GetAllAsync");
		var token = await _authService.Login(login);

		return Ok(new { Token = token });
	}
}
