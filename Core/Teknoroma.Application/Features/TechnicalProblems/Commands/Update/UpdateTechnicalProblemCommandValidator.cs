using FluentValidation;
using Teknoroma.Application.Features.TechnicalProblems.Contants;

namespace Teknoroma.Application.Features.TechnicalProblems.Commands.Update
{
    public class UpdateTechnicalProblemCommandValidator:AbstractValidator<UpdateTechnicalProblemCommandRequest>
    {
        public UpdateTechnicalProblemCommandValidator()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage(TechnicalProblemsMessages.IDNotNull);

            RuleFor(x => x.ReportedProblem).NotEmpty().WithMessage(TechnicalProblemsMessages.ReportedProblemNotNull)
               .MaximumLength(500).WithMessage(TechnicalProblemsMessages.ReportedProblemMaxLenght);

            RuleFor(x => x.ProblemSolution).MaximumLength(500).WithMessage(TechnicalProblemsMessages.ProblemSolutionMaxLenght);

            RuleFor(x => x.BranchId).NotEmpty().WithMessage(TechnicalProblemsMessages.BranchIdNotNull);

            RuleFor(x => x.EmployeeId).NotEmpty().WithMessage(TechnicalProblemsMessages.EmployeeIdNotNull);
        }
    }
}
