using Domain.User.DTOs;
using Domain.User.Entities;

namespace UserApi.Repositories.v2.Interfaces;

public interface ICustomerRepository
{
    Task<List<CustomerResponseDto>> GetAllCustomersAsync();
	Task CreateCustomerAsync(Customer customer);
	Task<Customer> GetCustomerByEmailAsync(string email);
	Task<Customer> GetCustomerByCpfAsync(string cpf);
}