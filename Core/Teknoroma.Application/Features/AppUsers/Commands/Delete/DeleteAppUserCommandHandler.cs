using MediatR;
using Microsoft.AspNetCore.Identity;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.AppUsers.Command.Delete
{
    public class DeleteAppUserCommandHandler : IRequestHandler<DeleteAppUserCommandRequest, Unit>
    {
        private readonly UserManager<AppUser> _userManager;

        public DeleteAppUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public Task<Unit> Handle(DeleteAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
