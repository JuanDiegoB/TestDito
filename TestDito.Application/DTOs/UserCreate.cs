using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDito.Application.DTOs
{
	public class UserCreate
	{
		public string Name { get; set; } = string.Empty;
		public string Lastname { get; set; } = string.Empty;
		public string IdentificationType { get; set; } = string.Empty;
		public string IdentificationNumber { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
	}
}
