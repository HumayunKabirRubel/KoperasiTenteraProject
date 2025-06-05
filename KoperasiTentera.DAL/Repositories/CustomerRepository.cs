using KoperasiTentera.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace KoperasiTentera.DAL
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly KTDbContext _dbContext;
        public CustomerRepository(KTDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync() => await _dbContext.Customers.ToListAsync();
        public async Task<Customer> GetByICNumberAsync(string icnumber)
        {
            return await _dbContext.Customers.FirstOrDefaultAsync(el => el.ICNumber == icnumber);
        }
        public async Task<int> AddAsync(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(Customer customer)
        {
            _dbContext.Customers.Update(customer);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
