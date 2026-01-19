using Infrastructure.Data.Bearer_Token.Settings;
using Infrastructure.Data.Mongo;
using Infrastructure.Data.Mongo.Settings;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure.Data;

public static class Bootstrap
{
	public static IServiceCollection AddMongoSettings(this IServiceCollection service, IConfiguration configuration)
	{
		var settings = configuration.GetSection("MongoSettings").Get<MongoDbSettings>();

		return service
			.AddSingleton(settings ?? throw new ArgumentNullException("Connection null error"))
			.AddSingleton<MongoContext>();
	}

	public static IServiceCollection AddTokenSettings(this IServiceCollection service, IConfiguration configuration)
	{
		var settings = configuration.GetSection("JwtSettings").Get<TokenSettings>();
		return service.AddSingleton(settings ?? throw new ArgumentNullException("Token configuration error"));
	}

	public static AuthenticationBuilder AddTokenAuthentication(this IServiceCollection service, IConfiguration configuration)
	{
		var authentication = new AuthenticationOptions();
		var tokenKey = Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"] ?? string.Empty);
		var jwtBearerOptions = new JwtBearerOptions();

		authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
		authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

		jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
		{
			ValidateLifetime = true,
			ClockSkew = TimeSpan.Zero,
			ValidateAudience = true,
			ValidAudience = configuration["JwtSettings:Audience"],
			ValidateIssuer = true,
			ValidIssuer = configuration["JwtSettings:Issuer"],
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(tokenKey)
		};

		return service
				.AddAuthentication(options => { options = authentication; })
				.AddJwtBearer(options => { options = jwtBearerOptions; });
	}

}
