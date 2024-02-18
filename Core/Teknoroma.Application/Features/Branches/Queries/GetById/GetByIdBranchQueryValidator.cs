using FluentValidation;
using Teknoroma.Application.Features.Branches.Constants;

namespace Teknoroma.Application.Features.Branches.Queries.GetById
{
	public class GetByIdBranchQueryValidator:AbstractValidator<GetByIdBranchQueryRequest>
	{
		public GetByIdBranchQueryValidator()
		{
			RuleFor(x => x.ID).NotEmpty().WithMessage(BranchesMessages.IDNotNull);
		}
	}
}
