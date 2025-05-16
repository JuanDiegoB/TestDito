using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestDito.Application.DTOs;
using TestDito.Application.Interfaces;
using TestDito.Application.Interfaces.Services;

namespace TestDito.API.Controllers;

[Route("api/users")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
	private readonly ILogger<UserController> _logger;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserService _userService;

	public UserController(
		ILogger<UserController> logger, 
		IUnitOfWork unitOfWork, 
		IUserService userService)
	{
		_logger = logger;
		_unitOfWork = unitOfWork;
		_userService = userService;
	}

	/// <summary>
	///		Obtener todos los Usuarios.
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	[Route("")]
	public async Task<IActionResult> GetAllAsync()
	{
		_logger.LogInformation("Inicio: GetAllAsync");

		return Ok(await _userService.GetAllAsync());
	}

	/// <summary>
	///		Obtener usuario especifico.
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	[HttpGet]
	[Route("{id:int}")]
	public async Task<IActionResult> GetAsync(int id)
	{
		_logger.LogInformation("Inicio: GetAsync");
		return Ok(await _userService.GetAsync(id));
	}

	/// <summary>
	///		Crear Usuario.
	/// </summary>
	/// <param name="userDto"></param>
	/// <returns></returns>
	[HttpPost]
	public async Task<IActionResult> CreateAsync([FromBody] UserCreate userCreate)
	{
		_logger.LogInformation("Inicio: GetAsync");
		await using var transaction = await _unitOfWork.BeginTransactionAsync();

		try
		{
			await _userService.CreateAsync(userCreate);

			await _unitOfWork.SaveChangesAsync();
			await transaction.CommitAsync();

			return Ok();
		}
		catch
		{
			await transaction.RollbackAsync();
			throw;
		}
	}

	/// <summary>
	///		Actualizar Usuario.
	/// </summary>
	/// <param name="id"></param>
	/// <param name="userDto"></param>
	/// <returns></returns>
	[HttpPut]
	[Route("{id:int}")]
	public async Task<IActionResult> UpdateAsync(int id, [FromBody] UserDto userDto)
	{
		_logger.LogInformation("Inicio: UpdateAsync");
		await using var transaction = await _unitOfWork.BeginTransactionAsync();

		try
		{
			if (id != userDto.Id)
			{
				return BadRequest();
			}

			await _userService.UpdateAsync(userDto);

			await _unitOfWork.SaveChangesAsync();
			await transaction.CommitAsync();

			return Ok();
		}
		catch
		{
			await transaction.RollbackAsync();
			throw;
		}
	}

	/// <summary>
	///		Eliminar Usuario.
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	[HttpDelete]
	[Route("{id:int}")]
	public async Task<IActionResult> DeleteAsync(int id)
	{
		_logger.LogInformation("Inicio: DeleteAsync");
		await using var transaction = await _unitOfWork.BeginTransactionAsync();

		try
		{
			await _userService.DeleteAsync(id);

			await _unitOfWork.SaveChangesAsync();
			await transaction.CommitAsync();

			return Ok();
		}
		catch
		{
			await transaction.RollbackAsync();
			throw;
		}
	}
}
