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

		public async Task<string?> GetRole(int userId)
		{
			int roleId = _db.UserRoles.Where(u => u.userId == userId).Select(u => u.roleId).FirstOrDefault();
			string role = _db.Role.Where(r => r.id == roleId).Select(r => r.rolename).FirstOrDefault();
			return role;
		}

		public async Task<User?> Checkuser(string email, string password)
		{
			var user = _db.User.FirstOrDefault(u=> u.email == email);

			return user != null ? user : null;
		}
	}
}
