using FluentValidation;
using Teknoroma.Application.Features.TechnicalProblems.Contants;

namespace Teknoroma.Application.Features.TechnicalProblems.Queries.GetById
{
    public class GetByIdTechnicalProblemQueryValidator:AbstractValidator<GetByIdTechnicalProblemQueryRequest>
    {
        public GetByIdTechnicalProblemQueryValidator()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage(TechnicalProblemsMessages.IDNotNull);
        }
    }
}
