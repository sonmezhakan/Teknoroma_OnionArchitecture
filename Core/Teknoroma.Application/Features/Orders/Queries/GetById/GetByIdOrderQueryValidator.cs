using FluentValidation;
using Teknoroma.Application.Features.Orders.Contants;

namespace Teknoroma.Application.Features.Orders.Queries.GetById
{
	public class GetByIdOrderQueryValidator:AbstractValidator<GetByIdOrderQueryRequest>
	{
        public GetByIdOrderQueryValidator()
        {
            RuleFor(x=>x.ID).NotEmpty().WithMessage(OrdersMessages.IDNotNull);
        }
    }
}
