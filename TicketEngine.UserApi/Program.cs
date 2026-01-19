using Infrastructure.Data.Bearer_Token;
using Infrastructure.Data.Bearer_Token.Interfaces;
using Infrastructure.Data.Extensions;
using Infrastructure.Data.Mongo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UserApi.Repositories.v1;
using UserApi.Repositories.v1.Interfaces;
using UserApi.Services.v1;
using UserApi.Services.v1.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddMongoSettings(builder.Configuration);
builder.Services.AddTokenSettings(builder.Configuration);

builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
	var configuration = builder.Configuration;
	var tokenKey = Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"] ?? string.Empty);

	options.TokenValidationParameters = new TokenValidationParameters()
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
});

builder.Services.AddAuthorization();

builder.Services.AddSingleton<MongoContext>();

builder.Services.AddScoped<ICustomerRepository, CustomerRespository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAuthToken, AuthToken>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
