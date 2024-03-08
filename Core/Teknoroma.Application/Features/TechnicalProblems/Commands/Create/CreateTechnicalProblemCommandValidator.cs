using FluentValidation;
using Teknoroma.Application.Features.TechnicalProblems.Contants;

namespace Teknoroma.Application.Features.TechnicalProblems.Commands.Create
{
    public class CreateTechnicalProblemCommandValidator:AbstractValidator<CreateTechnicalProblemCommandRequest>
    {
        public CreateTechnicalProblemCommandValidator()
        {
            RuleFor(x => x.ReportedProblem).NotEmpty().WithMessage(TechnicalProblemsMessages.ReportedProblemNotNull)
                .MaximumLength(500).WithMessage(TechnicalProblemsMessages.ReportedProblemMaxLenght);

            RuleFor(x => x.BranchId).NotEmpty().WithMessage(TechnicalProblemsMessages.BranchIdNotNull);

            RuleFor(x => x.EmployeeId).NotEmpty().WithMessage(TechnicalProblemsMessages.EmployeeIdNotNull);
        }
    }
}
