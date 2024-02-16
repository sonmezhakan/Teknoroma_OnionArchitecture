using Teknoroma.Domain.Abstracts;
using Teknoroma.Domain.Enums;

namespace Teknoroma.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public Customer()
        {
            Invoice = InvoiceEnum.Person;
        }
        public string FullName { get; set; }
        public string? ContactName { get; set; }
        public string? ContactTitle { get; set; }
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public InvoiceEnum Invoice { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}