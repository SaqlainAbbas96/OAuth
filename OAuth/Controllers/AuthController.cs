using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OAuth.Models;
using OAuth.Models.Dtos;
using OAuth.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace OAuth.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IConfiguration config;
		private static User user = new User();

		private readonly IUserService userService;

		public AuthController(IConfiguration configuration, IUserService userService)
		{
			config = configuration;
			this.userService = userService;
		}

		[HttpPost]
		public async Task<ActionResult<User>> Register(UserDto userDto)
		{
			userService.PasswordHash(userDto.password, out byte[] passwordHash, out byte[] passwordSalt);
			user.username = userDto.username;
			user.passwordHash = passwordHash;
			user.passwordSalt = passwordSalt;

			return Ok(user);
		}

		[HttpPost("Login")]
		public async Task<ActionResult<string>> Login(UserDto userDto) 
		{
			if (user.username != userDto.username) 
			{
				return BadRequest("User not found");
			}

			if (!userService.VerifyHashPassword(userDto.password, user.passwordHash, user.passwordSalt)) 
			{
				return BadRequest("Wrong Password");
			}

			string jwt = userService.GenerateToken(config,user);
			return Ok(jwt);

		}
	}
}
