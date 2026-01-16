using Infrastructure.Data.Mongo.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data.Extensions;

public static class ServiceCollectionExtension
{
	public static IServiceCollection AddMongo(this IServiceCollection service, IConfiguration configuration)
	{
		var settings = configuration.GetSection("MongoSettings").Get<MongoDbSettings>();

		return service.AddSingleton(settings ?? throw new ArgumentNullException("Connection null error"));
	}
}
