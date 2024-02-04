namespace OAuth.Services
{
	public interface IJwtParams
	{
		string GetJwtKey();
		string GetJwtAudiance();
		string GetJwtIssuer();
	}
}
