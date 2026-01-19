using Domain.User.Entities;
using Domain.User.Messages.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserApi.Services.v1.Interfaces;

namespace UserApi.Controllers.v1;

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

    [Authorize(Roles.Staff)]
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllCustomers()
    {
        try
        {
            var customers = _customerService.GetAllCustomersAsync();

            return Ok("vc esta autorizado");
        }
        catch (Exception ex)
        {
            return StatusCode(403, ex.Message);
        }
    }
}
