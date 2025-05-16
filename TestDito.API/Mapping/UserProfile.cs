using AutoMapper;
using TestDito.Application.DTOs;
using TestDito.Domain.Entities;

namespace TestDito.API.Mapping;

public class UserProfile : Profile
{
	public UserProfile()
	{
		CreateMap<UserDto, User>();
		CreateMap<User, UserDto>();
		CreateMap<UserCreate, User>();
	}	
}
