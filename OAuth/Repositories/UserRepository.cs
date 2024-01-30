using OAuth.Models;
using OAuth.Models.Dtos;

namespace OAuth.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly DBContext _db;
		public UserRepository(DBContext db)
		{
			_db = db;
		}

		public async Task<string> RegisterUser(User user)
		{
			_db.User.Add(user);
			await _db.SaveChangesAsync();

			return "User registered successfully";
		}

		public User GetUserByEmail(string email)
		{
			var users = _db.User.Where(x => x.email == email).FirstOrDefault();
			return users;
		}
	}
}
