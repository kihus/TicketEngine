using Domain.TicketEngine.CustomerApi.DTOs;
using Domain.TicketEngine.CustomerApi.Entities;
using Domain.TicketEngine.CustomerApi.Extensions;
using Domain.TicketEngine.CustomerApi.Messages.Commands;
using Infrastructure.CustomerApi.Data.Mongo;
using MongoDB.Driver;
using TicketEngine.CustomerApi.Repositories.v1.Interfaces;

namespace TicketEngine.CustomerApi.Repositories.v1;

public class CustomerRespository(
    MongoContext mongoDatabase
    ) : ICustomerRepository
{
    private readonly IMongoCollection<Customer> _customerCollection = mongoDatabase.Customers;

	public async Task CreateCustomerAsync(Customer customer)
	{
		try
		{
            await _customerCollection.InsertOneAsync(customer);
		}
		catch (MongoException ex)
		{
			throw new MongoException("An mongo error occurred while process your request: " + ex.Message);
		}
	}

	public async Task<IEnumerable<CustomerResponseDto>> GetAllCustomersAsync()
    {
        try
        {
            var customers = await _customerCollection.Find(_ => true).ToListAsync();

            return [.. customers.Select(c => c.ToDto())];
        }
        catch (MongoException ex)
        {
            throw new MongoException("An mongo error occurred while process your request: " + ex.Message);
        }
    }
}
