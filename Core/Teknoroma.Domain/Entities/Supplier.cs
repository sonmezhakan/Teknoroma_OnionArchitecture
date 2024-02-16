using Teknoroma.Domain.Abstracts;

namespace Teknoroma.Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public string CompanyName { get; set; }
        public string? ContactName { get; set; }
        public string? ContactTitle { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? WebSite { get; set; }
    }
}