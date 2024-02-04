namespace OAuth.Services
{
	public class JwtParams : IJwtParams
	{
		private static string key = "This is a Secret key for oauth project solution";
		private static string audiance = "https://localhost:7051";
		private static string issuer = "https://localhost:7051";

		public string GetJwtKey()
		{
			return key;
		}
		public string GetJwtAudiance()
		{
			return audiance;
		}
		public string GetJwtIssuer()
		{
			return issuer;
		}
	}
}
