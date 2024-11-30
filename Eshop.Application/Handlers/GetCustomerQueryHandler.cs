using Eshop.Application.DTOs;
using Eshop.Application.Queries;
using Eshop.Domain.Repositories;
using System.Threading.Tasks;

namespace Eshop.Application.Handlers;

public class GetCustomerQueryHandler
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<CustomerDto> Handle(GetCustomerQuery query)
    {
        var customer = await _customerRepository.GetByIdAsync(query.CustomerId);
        if (customer == null) return null;

        return new CustomerDto
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email
        };
    }
}