using FluentValidation;
using Teknoroma.Application.Features.OrderDetails.Contants;

namespace Teknoroma.Application.Features.OrderDetails.Queries.GetById
{
	public class GetByIdOrderDetailQueryValidator:AbstractValidator<GetByIdOrderDetailQueryRequest>
	{
        public GetByIdOrderDetailQueryValidator()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage(OrderDetailsMessages.IDNotNull);
        }
    }
}
