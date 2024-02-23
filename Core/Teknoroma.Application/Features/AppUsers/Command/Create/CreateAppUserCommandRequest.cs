using MediatR;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.AppUsers.Command.Create
{
    public class CreateAppUserCommandRequest:IRequest<Unit>, ITransactionalRequest
	{
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
		public List<string>? AppUserRoles { get; set; }
	}
}
