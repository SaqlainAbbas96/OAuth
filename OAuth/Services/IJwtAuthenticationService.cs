namespace OAuth.Services
{
	public interface IJwtAuthenticationService
	{
		string GenerateToken(string username, string userrole);
	}
}
