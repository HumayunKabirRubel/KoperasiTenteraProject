using KoperasiTentera.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace KoperasiTentera.DAL
{
    public class KTDbContext : DbContext
    {
        public KTDbContext(DbContextOptions<KTDbContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
    }
}