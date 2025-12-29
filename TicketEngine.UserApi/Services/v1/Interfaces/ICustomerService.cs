using Domain.TicketEngine.CustomerApi.DTOs;
using Domain.TicketEngine.CustomerApi.Messages.Commands;

namespace TicketEngine.CustomerApi.Services.v1.Interfaces;

public interface ICustomerService
{
	Task CreateCustomerAsync(CreateCustomerCommand customerCommand);

	Task<IEnumerable<CustomerResponseDto>> GetAllCustomersAsync(); 
}