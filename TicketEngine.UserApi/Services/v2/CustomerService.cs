using Domain.User.DTOs;
using Domain.User.Entities;
using Domain.User.Extensions;
using Domain.User.Messages.Commands;
using Infrastructure.Data.Bearer_Token.Interfaces;
using UserApi.Repositories.v2.Interfaces;
using UserApi.Services.v2.Interfaces;
using static BCrypt.Net.BCrypt;

namespace UserApi.Services.v2;

public class CustomerService(
	ICustomerRepository customerRepository,
	IAuthToken authToken
	) : ICustomerService
{
	private readonly ICustomerRepository _customerRepository = customerRepository;
	private readonly IAuthToken _authToken = authToken;
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

	public async Task<List<CustomerResponseDto>> GetAllCustomersAsync()
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
			var customer = await _customerRepository.GetCustomerByEmailAsync(login.Email);

			if (customer is null)
				throw new ArgumentException("Error! User not found!");

			if (!Verify(login.Password, customer.Password))
				throw new ArgumentException("Error! Passowords don't match");

			return _authToken.GenerateToken(customer);
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<CustomerResponseDto?> GetCustomerByCpfAsync(string cpf)
	{
		try
		{
			var customer = await _customerRepository.GetCustomerByCpfAsync(cpf);

			return customer.ToDto();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

}
