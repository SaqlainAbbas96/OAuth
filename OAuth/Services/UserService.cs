using Microsoft.IdentityModel.Tokens;
using OAuth.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace OAuth.Services
{
	public class UserService : IUserService
	{
		public void PasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			using (var h = new HMACSHA512())
			{
				passwordSalt = h.Key;
				passwordHash = h.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
			}
		}

		public bool VerifyHashPassword(string password, byte[] passwordHash, byte[] passwordSalt)
		{
			using (var h = new HMACSHA512(passwordSalt))
			{
				var hash = h.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
				return hash.SequenceEqual(passwordHash);
			}
		}

		public string GenerateToken(IConfiguration config, User user)
		{
			List<Claim> claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.username),
				new Claim(ClaimTypes.Role, "Admin")
			};

			var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(config.GetSection("Settings:Token").Value));

			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

			var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);

			var jwt = new JwtSecurityTokenHandler().WriteToken(token);

			return jwt;

		}
	}
}
