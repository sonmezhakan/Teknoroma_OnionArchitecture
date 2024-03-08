using FluentValidation;
using Teknoroma.Application.Features.TechnicalProblems.Contants;

namespace Teknoroma.Application.Features.TechnicalProblems.Commands.Delete
{
    public class DeleteTechnicalProblemCommandValidator:AbstractValidator<DeleteTechnicalProblemCommandRequest>
    {
        public DeleteTechnicalProblemCommandValidator()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage(TechnicalProblemsMessages.IDNotNull);
        }
    }
}
