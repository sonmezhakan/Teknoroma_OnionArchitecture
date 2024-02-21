
using MediatR;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.AppUserProfiles.Command.Update
{
    public class UpdateAppUserProfileCommandRequest:IRequest<Unit>, ITransactionalRequest
	{
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? NationalityNumber { get; set; }
        public string? Address { get; set; }
        public string? ImagePath { get; set; }
    }
}
