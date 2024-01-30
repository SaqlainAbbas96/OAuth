using OAuth.Models;

namespace OAuth.Repositories
{
	public interface IUserRepository
	{
		Task<string> RegisterUser(User user);

		User GetUserByEmail(string email);
	}
}
