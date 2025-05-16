using TestDito.Application.DTOs;

namespace TestDito.Application.Interfaces.Services;

public interface IAuthService
{
	Task<string> Login(LoginDto login);
}
