using Eshop.Domain.Repositories;
using Eshop.Application.Commands;
using Eshop.Domain.Models;
using Eshop.Domain.Events;
using System.Threading.Tasks;

namespace Eshop.Application.Handlers
{
    public class CreateCustomerCommandHandler
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task Handle(CreateCustomerCommand command)
        {
            var customer = new Customer(command.Name, command.Email);
            await _customerRepository.AddAsync(customer);
            // Generate CustomerCreatedEvent
            var customerCreatedEvent = new CustomerCreatedEvent(customer.Id);
            // Publish event (implementation depends on your event bus)
        }
    }
}