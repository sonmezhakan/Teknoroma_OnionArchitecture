using FluentValidation;
using Teknoroma.Application.Features.OrderDetails.Contants;

namespace Teknoroma.Application.Features.OrderDetails.Queries.GetByProductId
{
	public class GetByProductIdOrderDetailQueryValidator:AbstractValidator<GetByProductIdOrderDetailQueryRequest>
	{
        public GetByProductIdOrderDetailQueryValidator()
        {
            RuleFor(x=>x.ProductId).NotEmpty().WithMessage(OrderDetailsMessages.ProductIDNotNull);
        }
    }
}
