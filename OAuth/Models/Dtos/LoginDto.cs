using System.ComponentModel.DataAnnotations;

namespace OAuth.Models.Dtos
{
	public class LoginDto
	{
		[Required]
		[EmailAddress]
		public string email { get; set; }

		[Required]
		public string password { get; set; }
	}
}
