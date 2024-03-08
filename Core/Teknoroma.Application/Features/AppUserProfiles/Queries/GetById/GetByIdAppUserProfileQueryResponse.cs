
namespace Teknoroma.Application.Features.AppUserProfiles.Quıeries.GetById
{
    public class GetByIdAppUserProfileQueryResponse
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalityNumber { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
    }
}
