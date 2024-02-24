using FluentValidation;

namespace Teknoroma.Application.Features.Orders.Queries.GetById
{
	public class GetByIdOrderQueryValidator:AbstractValidator<GetByIdOrderQueryRequest>
	{
        public GetByIdOrderQueryValidator()
        {
            RuleFor(x=>x.ID).NotEmpty().WithMessage("");
        }
    }
}
