using TestDito.Application.DTOs;
using TestDito.Domain.Entities;

namespace TestDito.Application.Interfaces.Repositories;

public interface IUserRepository
{
	Task<IEnumerable<UserDto>> GetAllAsync();

	Task<User> GetAsync(int id);

	Task<User> GetByIdNumberAsync(string IdNumber);

	Task CreateAsync(User user);

	void Update(User user);

	void Delete(User user);
}
