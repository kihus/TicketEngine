using Infrastructure.Data.Bearer_Token.Settings;
using Infrastructure.Data.Mongo.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data.Extensions;

public static class ServiceCollectionExtension
{
	public static IServiceCollection AddMongoSettings(this IServiceCollection service, IConfiguration configuration)
	{
		var settings = configuration.GetSection("MongoSettings").Get<MongoDbSettings>();

		return service.AddSingleton(settings ?? throw new ArgumentNullException("Connection null error"));
	}

	public static IServiceCollection AddTokenSettings(this IServiceCollection service, IConfiguration configuration)
	{
		var settings = configuration.GetSection("JwtSettings").Get<TokenSettings>();
		return service.AddSingleton(settings ?? throw new ArgumentNullException("Token configuration error"));
	}
}
