using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using TestDito.Application.Common;
using TestDito.Application.DTOs;
using TestDito.Application.Interfaces.Repositories;
using TestDito.Application.Interfaces.Services;

namespace TestDito.Application.Services;

public class AuthService : IAuthService
{
	private readonly IUserRepository _userRepository;
	private readonly JwtSettings _jwtSettings;
	public AuthService(IUserRepository userRepository, IOptions<JwtSettings> jwtOptions)
	{
		_userRepository = userRepository;
		_jwtSettings = jwtOptions.Value;
	}

	public async Task<string> Login(LoginDto login)
	{
		var user = await _userRepository.GetByIdNumberAsync(login.IdentificationNumber);

		if (user is null || !user.IsAdmin ||
			!BCrypt.Net.BCrypt.Verify(login.Password, user.Password))
		{
			throw new Exception($"Credenciales invalidas.");
		}

		return GenerateToken(user.IdentificationNumber, user.Email);
	}

	private string GenerateToken(string userId, string userName)
	{
		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
		var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


		var claims = new[]
		{
			new Claim(JwtRegisteredClaimNames.Sub, userId),
			new Claim(JwtRegisteredClaimNames.UniqueName, userName),
			new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
		};

		var token = new JwtSecurityToken(
			issuer: _jwtSettings.Issuer,
			audience: _jwtSettings.Audience,
			claims: claims,
			expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
			signingCredentials: creds);

		return new JwtSecurityTokenHandler().WriteToken(token);
	}
}
