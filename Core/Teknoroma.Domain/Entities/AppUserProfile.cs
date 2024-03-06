using Teknoroma.Domain.Abstracts;

namespace Teknoroma.Domain.Entities
{
    public class AppUserProfile : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? NationalityNumber { get; set; }
        public string? Address { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
