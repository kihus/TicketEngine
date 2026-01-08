using Domain.TicketEngine.CustomerApi.DTOs;
using Domain.TicketEngine.CustomerApi.Entities;
using Domain.TicketEngine.CustomerApi.Messages.Commands;

namespace Domain.TicketEngine.CustomerApi.Extensions;

public static class CustomerExtension
{
	public static CustomerResponseDto ToDto(this Customer customer)
	{
		if (customer is null)
			return null;

		return new CustomerResponseDto
		{
			Name = customer.Name,
			LastName = customer.LastName,
			Birthdate = DateOnly.FromDateTime(customer.Birthdate),
			Phone = customer.Phone,
			Role = customer.Role,
		};
	}

	public static Customer ToEntity(this CreateCustomerCommand customer, string email, string password)
	{
		if (customer is null)
			return null;

		return new Customer(
			customer.Name,
			customer.LastName,
			customer.Birthdate,
			customer.Phone,
			customer.Document,
			email,
			password,
			customer.Role
			);
	}
}
