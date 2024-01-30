using OAuth.Models;
using OAuth.Models.Dtos;
using System.Security.Cryptography;

namespace OAuth.Services
{
	public interface IUserService
	{
		Task<string> RegisterUser(UserDto userDto);
		void PasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

		User GetUserByEmail(string email);

		bool VerifyHashPassword(string password, byte[] passwordHash, byte[] passwordSalt);

		string GenerateToken(IConfiguration config, User user);

	}
}
