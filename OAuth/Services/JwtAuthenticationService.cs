using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OAuth.Services
{
	public class JwtAuthenticationService : IJwtAuthenticationService
	{

		private readonly IJwtParams _jwtParams;
		public JwtAuthenticationService(IJwtParams jwtParams)
		{
			_jwtParams = jwtParams;
		}

		public string GenerateToken(string username, string userrole)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_jwtParams.GetJwtKey());

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
				{
				new Claim(ClaimTypes.Name, username),
				new Claim(ClaimTypes.Role, userrole)
			}),

				Expires = DateTime.UtcNow.AddDays(1),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			var returnToken = tokenHandler.WriteToken(token);

			return returnToken;
		}
	}
}
