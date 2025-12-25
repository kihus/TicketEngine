using Domain.TicketEngine.CustomerApi.DTOs;

namespace TicketEngine.CustomerApi.Services.v1.Interfaces;

public interface ICustomerService
{
    Task<CustomerResponseDto> GetAllCustomersAsync(); 
}