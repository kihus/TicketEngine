using Infrastructure.CustomerApi.Data.Mongo;
using Infrastructure.CustomerApi.Data.Mongo.Settings;
using TicketEngine.CustomerApi.Repositories.v1;
using TicketEngine.CustomerApi.Repositories.v1.Interfaces;
using TicketEngine.CustomerApi.Services.v1;
using TicketEngine.CustomerApi.Services.v1.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton(mongo =>
{
    var settings = builder.Configuration.GetSection("MongoSettings").Get<MongoDbSettings>();

    return settings is null 
        ? throw new ArgumentNullException("Mongo settings cannot be null") 
        : settings;
});

builder.Services.AddSingleton<MongoContext>();

builder.Services.AddScoped<ICustomerRepository, CustomerRespository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
