﻿using System.ComponentModel.DataAnnotations;

namespace OAuth.Models.Dtos
{
	public class UserDto
	{
		[Required]
		[EmailAddress]
		public string email { get; set; }

		[Required]
		public string password { get; set; }
	}
}
