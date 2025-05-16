namespace TestDito.Application.DTOs;

public class UserDto
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Lastname { get; set; } = string.Empty;
	public string IdentificationType { get; set; } = string.Empty;
	public string IdentificationNumber { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public bool IsAdmin { get; set; } = false;
}
