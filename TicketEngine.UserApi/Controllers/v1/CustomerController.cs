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
