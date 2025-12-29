using Domain.TicketEngine.CustomerApi.DTOs;
using Domain.TicketEngine.CustomerApi.Entities;

namespace TicketEngine.CustomerApi.Repositories.v1.Interfaces;

public interface ICustomerRepository
{
    Task<IEnumerable<CustomerResponseDto>> GetAllCustomersAsync();
	Task CreateCustomerAsync(Customer customer);
	Task<Customer> GetUserByEmailAsync(string email);
}