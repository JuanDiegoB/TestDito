using Microsoft.EntityFrameworkCore;
using TestDito.Application.DTOs;
using TestDito.Application.Interfaces.Repositories;
using TestDito.Domain.Entities;

namespace TestDito.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
	readonly DatabaseContext _databaseContext;

	public UserRepository(DatabaseContext databaseContext)
	{
		_databaseContext = databaseContext;
	}

	public async Task<IEnumerable<UserDto>> GetAllAsync()
	{
		return await _databaseContext.Users
			.Select(u => new UserDto
			{
				Id = u.Id,
				Name = u.Name,
				Lastname = u.Lastname,
				IdentificationType = u.IdentificationType,
				IdentificationNumber = u.IdentificationNumber,
				Email = u.Email
			}).ToListAsync();
	}

	public async Task<User> GetAsync(int id)
	{
		var user = await _databaseContext.Users
			.Where(u => u.Id.Equals(id))
			.SingleOrDefaultAsync();

		if (user == null)
		{
			throw new Exception($"Usuario con el ID {id} no encontrado.");
		}

		return user;
	}

	public async Task<User> GetByIdNumberAsync(string idNumber)
	{
		var user = await _databaseContext.Users
			.Where(u => u.IdentificationNumber.Equals(idNumber))
			.SingleOrDefaultAsync();

		if (user == null)
		{
			throw new Exception($"Usuario con el número de identificación {idNumber} no encontrado.");
		}

		return user;
	}

	public async Task CreateAsync(User user)
	{		
		await _databaseContext.AddAsync(user);
	}

	public void Update(User user)
	{
		_databaseContext.Update(user);
	}

	public void Delete(User user)
	{
		_databaseContext.Remove(user);
	}
}
