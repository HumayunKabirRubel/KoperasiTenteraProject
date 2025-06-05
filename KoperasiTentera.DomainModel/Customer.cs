using System.ComponentModel.DataAnnotations;

namespace KoperasiTentera.DomainModel
{
    public class Customer
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string CustomerName { get; set; }

        [MaxLength(20)]
        public string ICNumber { get; set; }

        [MaxLength(20)]
        public string MobileNumber { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(6)]
        public string? PIN { get; set; }
    }
}