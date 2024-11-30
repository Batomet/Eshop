namespace Eshop.Domain.Events;

public class CustomerCreatedEvent
{
    public Guid CustomerId { get; }

    public CustomerCreatedEvent(Guid customerId)
    {
        CustomerId = customerId;
    }
}