namespace Teknoroma.Application.Features.AppUsers.Queries.GetList
{
    public class GetAllAppUserQueryResponse
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalityNumber { get; set; }
        public string Address { get; set; }
    }
}
