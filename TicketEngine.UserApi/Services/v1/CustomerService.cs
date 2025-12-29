using Domain.TicketEngine.CustomerApi.DTOs;
using Domain.TicketEngine.CustomerApi.Entities;
using Domain.TicketEngine.CustomerApi.Extensions;
using Domain.TicketEngine.CustomerApi.Messages.Commands;
using Microsoft.AspNetCore.Mvc;
using TicketEngine.CustomerApi.Repositories.v1.Interfaces;
using TicketEngine.CustomerApi.Services.v1.Interfaces;
using static BCrypt.Net.BCrypt;

namespace TicketEngine.CustomerApi.Services.v1;

public class CustomerService(
	ICustomerRepository customerRepository
	) : ICustomerService
{
	private readonly ICustomerRepository _customerRepository = customerRepository;
	private readonly int _workFactor = 12;

	public async Task CreateCustomerAsync(CreateCustomerCommand customerCommand)
	{
		try
		{
			if (string.IsNullOrWhiteSpace(customerCommand.Role))
				throw new ArgumentNullException("Error! Role cannot be null!");

			if(!Roles.IsValid(customerCommand.Role))
				throw new Exception("Error! Role doesn't exits!");

			var password = HashPassword(customerCommand.Password, _workFactor);
			var email = customerCommand.Email.Trim().ToLower();

			var customer = customerCommand.ToEntity(email, password);

			await _customerRepository.CreateCustomerAsync(customer);
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<IEnumerable<CustomerResponseDto>> GetAllCustomersAsync()
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

	public async Task<string> GetTokenAuthAsync(GetLoginAuth login)
	{
		try
		{
			var customer = await _customerRepository.GetUserByEmailAsync(login.Email);

			if (customer is null)
				throw new ArgumentException("Error! User not found!");

			if (!Verify(customer.Password, login.Password))
				throw new ArgumentException("Error! Passowords don't match");

			return "goiaba";
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}
}
