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

		private readonly IUserService _userService;

		public AuthController(IConfiguration configuration, IUserService userService)
		{
			config = configuration;
			_userService = userService;
		}

		[HttpPost]
		public async Task<ActionResult<User>> Register(UserDto userDto)
		{
			var res = await _userService.RegisterUser(userDto);
			return Ok(res);
		}

		[HttpPost("Login")]
		public async Task<ActionResult<string>> Login(UserDto userDto)
		{
			var user = _userService.GetUserByEmail(userDto.email);

			if (user != null)
			{
				if (user.email != userDto.email)
					return BadRequest("Incorrect email");

				if (!_userService.VerifyHashPassword(userDto.password, user.passwordHash, user.passwordSalt))
					return BadRequest("Wrong Password");

				string jwt = _userService.GenerateToken(config, user);
				return Ok(jwt);
			}
			return BadRequest("User not found");
		}
	}
}
