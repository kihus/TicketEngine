using Domain.User.DTOs;
using Domain.User.Entities;
using Domain.User.Extensions;
using Infrastructure.Data.Mongo;
using MongoDB.Driver;
using UserApi.Repositories.v1.Interfaces;

namespace UserApi.Repositories.v1;

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

	public async Task<List<CustomerResponseDto>> GetAllCustomersAsync()
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

	public async Task<Customer> GetUserByEmailAsync(string email)
	{
		try
		{
			var user = await _customerCollection.Find(c => c.Email == email).FirstOrDefaultAsync();

			return user;
		}
		catch (MongoException ex)
		{
			throw new MongoException("An mongo error occured while process your request: " + ex.Message);
		}
	}
}
