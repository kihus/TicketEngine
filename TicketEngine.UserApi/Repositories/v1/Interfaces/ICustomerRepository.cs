using Domain.User.DTOs;
using Domain.User.Entities;

namespace UserApi.Repositories.v1.Interfaces;

public interface ICustomerRepository
{
    Task<IEnumerable<CustomerResponseDto>> GetAllCustomersAsync();
	Task CreateCustomerAsync(Customer customer);
	Task<Customer> GetUserByEmailAsync(string email);
}