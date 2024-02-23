using Teknoroma.Application.Features.AppUserRoles.Models;

namespace Teknoroma.Application.Features.AppUsers.Queries.GetById
{
    public class GetByIdAppUserQueryResponse
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string? NationalityNumber { get; set; }
        public string? Address { get; set; }
        public List<string>? AppUserRoles { get; set; }
    }
}
