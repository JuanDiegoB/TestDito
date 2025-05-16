using TestDito.Application.DTOs;

namespace TestDito.Application.Interfaces.Services;

public interface IUserService
{
	Task<IEnumerable<UserDto>> GetAllAsync();

	Task<UserDto> GetAsync(int id);

	Task<UserDto> GetByIdNumberAsync(string IdNumber);

	Task CreateAsync(UserCreate userCreate);

	Task UpdateAsync(UserDto userDto);

	Task DeleteAsync(int id);
}
