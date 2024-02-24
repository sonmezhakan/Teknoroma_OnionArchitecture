using FluentValidation;
using Teknoroma.Application.Features.OrderDetails.Contants;

namespace Teknoroma.Application.Features.OrderDetails.Queries.GetByOrderAndProductId
{
	public class GetByOrderAndProductIdOrderDetailQueryValidator:AbstractValidator<GetByOrderAndProductIdOrderDetailQueryRequest>
	{
        public GetByOrderAndProductIdOrderDetailQueryValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage(OrderDetailsMessages.ProductIDNotNull);

            RuleFor(x => x.OrderId).NotEmpty().WithMessage(OrderDetailsMessages.IDNotNull);
        }
    }
}
