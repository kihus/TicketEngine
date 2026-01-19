using Domain.User.DTOs;
using Domain.User.Entities;
using Domain.User.Messages.Commands;
using System.Diagnostics;

namespace Domain.User.Extensions;

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
