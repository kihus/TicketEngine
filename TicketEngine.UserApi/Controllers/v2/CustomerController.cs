using Domain.User.Messages.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserApi.Services.v2.Interfaces;

namespace UserApi.Controllers.v2;

[Route("api/v2/[controller]")]
[ApiController]
public class CustomerController(
    ICustomerService customerService
    ) : ControllerBase
{
    private readonly ICustomerService _customerService = customerService;

    [HttpPost("register")]
    public async Task<IActionResult> CreateCustomerAsync([FromBody] CreateCustomerCommand customerCommand)
    {
        try
        {
            if (customerCommand is null)
                return BadRequest("Error! Customer command cannot be null");

            await _customerService.CreateCustomerAsync(customerCommand);

            return Created();
        }
        catch (ArgumentNullException ex)
        {
            return StatusCode(400, ex.Message);
		}
        catch (Exception ex)
        {
            return StatusCode(404, ex.Message);
        }
    }

    [HttpPost("auth")]
    public async Task<IActionResult> GetTokenAuthAsync([FromBody] GetLoginAuth login)
    {
        try
        {
            if (login is null)
                return BadRequest("Error! Login command cannot be null");

            var token = await _customerService.GetTokenAuthAsync(login);

            return Ok(token);
        }
        catch(ArgumentNullException ex)
        {
            return StatusCode(400, ex.Message);
        }
        catch(Exception ex)
        {
            return StatusCode(404, ex.Message);
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllCustomersAsync()
    {
        try
        {
            var customers = await _customerService.GetAllCustomersAsync();

            return Ok(customers);
        }
        catch (Exception ex)
        {
            return StatusCode(403, ex.Message);
        }
    }
    [Authorize(Roles = "Staff,Admin")]
    [HttpGet("{cpf}")]
    public async Task<IActionResult> GetCustomerByCpfAsync(string cpf)
    {
        try
        {
            var customer = await _customerService.GetCustomerByCpfAsync(cpf);

            if (customer is null)
                return StatusCode(404, "Register not found");

            return Ok(customer);
        }
        catch (Exception ex)
        {
            return StatusCode(400, ex.Message);
        }
    }
}
