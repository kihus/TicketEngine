using Domain.TicketEngine.CustomerApi.DTOs;
using Domain.TicketEngine.CustomerApi.Messages.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketEngine.CustomerApi.Services.v1.Interfaces;

namespace TicketEngine.CustomerApi.Controllers.v1;

[Route("api/v1/[controller]")]
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
                return BadRequest("Error customer command cannot be null");

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

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        try
        {
            var customers = _customerService.GetAllCustomersAsync();

            return Ok(customers);
        }
        catch (Exception ex)
        {
            return StatusCode(403, ex.Message);
        }
    }
}
