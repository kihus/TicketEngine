using Domain.TicketEngine.CustomerApi.DTOs;
using TicketEngine.CustomerApi.Repositories.v1.Interfaces;
using TicketEngine.CustomerApi.Services.v1.Interfaces;

namespace TicketEngine.CustomerApi.Services.v1;

public class CustomerService(
    ICustomerRepository customerRepository
    ) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task<CustomerResponseDto> GetAllCustomersAsync()
    {
        try
        {
            var customers = await _customerRepository.GetAllCustomersAsync();
            return customers;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
