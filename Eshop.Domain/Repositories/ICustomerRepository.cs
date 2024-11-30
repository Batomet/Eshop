using Eshop.Domain.Models;
using System.Threading.Tasks;

namespace Eshop.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer);
        Task<Customer> GetByIdAsync(Guid customerId);
    }
}