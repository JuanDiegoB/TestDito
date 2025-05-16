using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestDito.Domain.Entities;

public class User
{
	[Key]
	public int Id { get; set; }

	[Required]
	[StringLength(100)]
	[DisplayName("Nombre")]
	public string Name { get; set; } = null!;

	[Required]
	[StringLength(100)]
	[DisplayName("Apellido")]
	public string Lastname { get; set; } = null!;

	[Required]
	[StringLength(2)]
	[DisplayName("Tipo de Identificación")]
	[AllowedValues("CC", "RC", "TI", "PA")]
	public string IdentificationType { get; set; } = null!;

	[Required]
	[StringLength(20)]
	[DisplayName("Numero de Identificación")]
	public string IdentificationNumber { get; set; } = null!;

	[Required]
	[StringLength(100)]
	[DisplayName("Contraseña")]
	public string Password { get; set; } = null!;

	[Required]
	[EmailAddress]
	[StringLength(100)]
	[DisplayName("Correo Electrónico")]
	public string Email { get; set; } = null!;

	public bool IsAdmin { get; set; } = false;
}
