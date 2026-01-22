using Infrastructure.Data;
using Infrastructure.Data.Bearer_Token;
using Infrastructure.Data.Bearer_Token.Interfaces;
using Microsoft.AspNetCore.Identity;
using UserApi.Repositories.v1;
using UserApi.Repositories.v1.Interfaces;
using UserApi.Services.v1;
using UserApi.Services.v1.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddMongoSettings(builder.Configuration);
builder.Services.AddTokenSettings(builder.Configuration);
builder.Services.AddTokenAuthentication(builder.Configuration);
builder.Services.AddFirestoreSettings(builder.Configuration);
builder.Services.AddInfrastructure();

builder.Services.AddAuthorization();

builder.Services.AddScoped<ICustomerRepository, CustomerRespository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAuthToken, AuthToken>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
