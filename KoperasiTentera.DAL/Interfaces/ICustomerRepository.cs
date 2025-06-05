using KoperasiTentera.DomainModel;

namespace KoperasiTentera.DAL
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetByICNumberAsync(string icnumber);
        Task<int> AddAsync(Customer customer);
        Task<int> UpdateAsync(Customer customer);
    }
}
