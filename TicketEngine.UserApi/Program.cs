using Infrastructure.Data.Bearer_Token;
using Infrastructure.Data.Bearer_Token.Interfaces;
using Infrastructure.Data.Bearer_Token.Settings;
using Infrastructure.Data.Extensions;
using Infrastructure.Data.Mongo;
using UserApi.Repositories.v1;
using UserApi.Repositories.v1.Interfaces;
using UserApi.Services.v1;
using UserApi.Services.v1.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddMongoSettings(builder.Configuration);
builder.Services.AddTokenSettings(builder.Configuration);

builder.Services.AddSingleton<MongoContext>();

builder.Services.AddScoped<ICustomerRepository, CustomerRespository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAuthToken, AuthToken>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
