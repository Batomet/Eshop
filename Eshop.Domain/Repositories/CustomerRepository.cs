using Eshop.Domain.Models;
using MongoDB.Driver;
using Eshop.Domain.Repositories;
using System.Threading.Tasks;

namespace Eshop.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMongoCollection<Customer> _customers;

        public CustomerRepository(IMongoDatabase database)
        {
            _customers = database.GetCollection<Customer>("Customers");
        }

        public async Task AddAsync(Customer customer)
        {
            await _customers.InsertOneAsync(customer);
        }

        public async Task<Customer> GetByIdAsync(Guid customerId)
        {
            return await _customers.Find(c => c.Id == customerId).FirstOrDefaultAsync();
        }
    }
}