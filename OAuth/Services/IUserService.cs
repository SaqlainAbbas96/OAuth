using OAuth.Models;
using System.Security.Cryptography;

namespace OAuth.Services
{
	public interface IUserService
	{
		void PasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

		bool VerifyHashPassword(string password, byte[] passwordHash, byte[] passwordSalt);

		string GenerateToken(IConfiguration config, User user);
	}
}
