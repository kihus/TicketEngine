using Infrastructure.CustomerApi.Data.Bearer_Token;
using Infrastructure.CustomerApi.Data.Bearer_Token.Interfaces;
using Infrastructure.CustomerApi.Data.Bearer_Token.Settings;
using Infrastructure.CustomerApi.Data.Extensions;
using Infrastructure.CustomerApi.Data.Mongo;
using Infrastructure.CustomerApi.Data.Mongo.Settings;
using TicketEngine.CustomerApi.Repositories.v1;
using TicketEngine.CustomerApi.Repositories.v1.Interfaces;
using TicketEngine.CustomerApi.Services.v1;
using TicketEngine.CustomerApi.Services.v1.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddMongo(builder.Configuration);

builder.Services.AddSingleton<MongoContext>();
builder.Services.AddSingleton<TokenSettings>();

builder.Services.AddScoped<ICustomerRepository, CustomerRespository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAuthToken, AuthToken>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
