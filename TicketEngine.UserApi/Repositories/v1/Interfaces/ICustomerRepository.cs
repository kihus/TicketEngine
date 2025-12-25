using Domain.TicketEngine.CustomerApi.DTOs;

namespace TicketEngine.CustomerApi.Repositories.v1.Interfaces;

public interface ICustomerRepository
{
    Task<CustomerResponseDto> GetAllCustomersAsync();
}