using Domain.TicketEngine.CustomerApi.DTOs;
using Domain.TicketEngine.CustomerApi.Entities;

namespace Domain.TicketEngine.CustomerApi.Extensions;

public static class CustomerExtension
{
    public static CustomerResponseDto ToDto(this Customer customer)
    {
        if (customer is null)
            return null;

        return new CustomerResponseDto();
    }
}
