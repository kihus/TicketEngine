using Domain.TicketEngine.CustomerApi.Entities;
using Infrastructure.Customer.Data.Mongo.Settings;
using MongoDB.Driver;

namespace Infrastructure.Customer.Data.Mongo;

public class MongoContext
{
    private readonly IMongoDatabase _database;

    public MongoContext(MongoDbSettings settings)
    {
        var client = new MongoClient(settings.ConnectionUri);
        _database = client.GetDatabase(settings.DatabaseName);
    }

    public IMongoCollection<Customer> Customers
        => _database.GetCollection<Customer>("Customers");
}
