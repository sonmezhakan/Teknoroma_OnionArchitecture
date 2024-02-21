using FluentValidation;
using Teknoroma.Application.Features.AppUsers.Contants;

namespace Teknoroma.Application.Features.AppUsers.Command.Delete
{
    public class DeleteAppUserCommandValidator:AbstractValidator<DeleteAppUserCommandRequest>
    {
        public DeleteAppUserCommandValidator()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage(AppUsersMessages.IDNotNull);
        }
    }
}
