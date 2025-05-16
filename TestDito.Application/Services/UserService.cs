using AutoMapper;
using System;
using TestDito.Application.DTOs;
using TestDito.Application.Interfaces.Repositories;
using TestDito.Application.Interfaces.Services;
using TestDito.Domain.Entities;

namespace TestDito.Application.Services;

public class UserService : IUserService
{
	public readonly IMapper _mapper;
	public readonly IUserRepository _userRepository;

	public UserService(IMapper mapper, IUserRepository userRepository)
	{
		_mapper = mapper;
		_userRepository = userRepository;
	}

	public async Task<IEnumerable<UserDto>> GetAllAsync()
	{
		return await _userRepository.GetAllAsync();
	}

	public async Task<UserDto> GetAsync(int id)
	{
		User user = await _userRepository.GetAsync(id);

		return _mapper.Map<UserDto>(user);
	}

	public async Task<UserDto> GetByIdNumberAsync(string idNumber)
	{
		User user = await _userRepository.GetByIdNumberAsync(idNumber);

		return _mapper.Map<UserDto>(user);
	}

	public async Task CreateAsync(UserCreate userCreate)
	{
		User newUser = _mapper.Map(userCreate, new User());

		newUser.Password = BCrypt.Net.BCrypt.HashPassword(userCreate.Password);

		await _userRepository.CreateAsync(newUser);
	}

	public async Task UpdateAsync(UserDto userDto)
	{
		User user = await _userRepository.GetAsync(userDto.Id);

		user.Name = userDto.Name;
		user.Lastname = userDto.Lastname;
		user.IdentificationType = userDto.IdentificationType;
		user.IdentificationNumber = userDto.IdentificationNumber;
		user.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
		user.Email = userDto.Email;

		_userRepository.Update(user);
	}

	public async Task DeleteAsync(int id)
	{
		User usuario = await _userRepository.GetAsync(id);

		_userRepository.Delete(usuario);
	}	
}
