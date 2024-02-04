using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace OAuth.Services
{
	public static class JwtAuthenticationConfig
	{
		public static void Configure(IServiceCollection services, string secretKey)
		{
			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			})
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = false,
						ValidateAudience = false,
						ValidateIssuerSigningKey = true,
						//ValidIssuer = issuer,
						//ValidAudience = audience,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))

					};
				});

			services.AddSwaggerGen(option =>
			{
				option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
				{
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer",
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
				});
				option.AddSecurityRequirement(new OpenApiSecurityRequirement
					 {
						 {
								 new OpenApiSecurityScheme
								 {
									 Reference = new OpenApiReference
									 {
										 Type = ReferenceType.SecurityScheme,
										 Id = "Bearer"
									 }
								 },
								 new string[] {}
						 }
					 });
			});
		}
	}
}
