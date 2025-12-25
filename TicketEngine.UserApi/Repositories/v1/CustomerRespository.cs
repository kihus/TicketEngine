using Domain.TicketEngine.CustomerApi.DTOs;
using Domain.TicketEngine.CustomerApi.Entities;
using Infrastructure.CustomerApi.Data.Mongo;
using MongoDB.Driver;
using TicketEngine.CustomerApi.Repositories.v1.Interfaces;

namespace TicketEngine.CustomerApi.Repositories.v1;

public class CustomerRespository(
    MongoContext mongoDatabase
    ) : ICustomerRepository
{
    private readonly IMongoCollection<Customer> _customerCollection = mongoDatabase.Customers;

    public async Task<CustomerResponseDto> GetAllCustomersAsync()
    {
        try
        {
            var customers = await _customerCollection.Find(_ => true).ToListAsync();

            return customers.ToDto();
        }
        catch (MongoException ex)
        {
            throw new MongoException("An mongo error occurred while process your request: " + ex.Message);
        }
    }
}
