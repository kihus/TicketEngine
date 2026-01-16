using Domain.User.DTOs;
using Domain.User.Messages.Commands;

namespace UserApi.Services.v1.Interfaces;

public interface ICustomerService
{
	Task CreateCustomerAsync(CreateCustomerCommand customerCommand);

	Task<IEnumerable<CustomerResponseDto>> GetAllCustomersAsync();

	Task<string> GetTokenAuthAsync(GetLoginAuth login);
}