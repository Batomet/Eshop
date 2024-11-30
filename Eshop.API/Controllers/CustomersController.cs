using Eshop.Application.Commands;
using Eshop.Application.Handlers;
using Query = Eshop.Application.Queries.GetCustomerQuery;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.API.Controllers;

[ApiController]
[Route("api/v1/customers")]
public class CustomersController : ControllerBase
{
    private readonly CreateCustomerCommandHandler _createCustomerCommandHandler;
    private readonly GetCustomerQueryHandler _getCustomerQueryHandler;

    public CustomersController(CreateCustomerCommandHandler createCustomerCommandHandler, GetCustomerQueryHandler getCustomerQueryHandler)
    {
        _createCustomerCommandHandler = createCustomerCommandHandler;
        _getCustomerQueryHandler = getCustomerQueryHandler;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
    {
        await _createCustomerCommandHandler.Handle(command);
        return Ok();
    }

    [HttpGet("{customerId}")]
    public async Task<IActionResult> GetCustomer(Guid customerId)
    {
        var query = new Query { CustomerId = customerId };
        var customer = await _getCustomerQueryHandler.Handle(query);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }
}