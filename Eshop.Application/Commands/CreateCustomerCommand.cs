namespace Eshop.Application.Commands;

public class CreateCustomerCommand
{
    public string Name { get; set; }
    public string Email { get; set; }
}

public class GetCustomerQuery
{
    public Guid CustomerId { get; set; }
}