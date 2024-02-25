using MediatR;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.AppUserProfiles.Command.Create
{
    public class CreateAppUserProfileCommandRequest:IRequest<Unit>,ITransactionalRequest
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
