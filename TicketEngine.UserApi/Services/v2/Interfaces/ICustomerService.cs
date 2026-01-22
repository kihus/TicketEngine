using Domain.User.DTOs;
using Domain.User.Entities;
using Domain.User.Messages.Commands;

namespace UserApi.Services.v2.Interfaces;

public interface ICustomerService
{
	Task CreateCustomerAsync(CreateCustomerCommand customerCommand);

	Task<List<CustomerResponseDto>> GetAllCustomersAsync();

	Task<string> GetTokenAuthAsync(GetLoginAuth login);
	Task<CustomerResponseDto?> GetCustomerByCpfAsync(string cpf);
}