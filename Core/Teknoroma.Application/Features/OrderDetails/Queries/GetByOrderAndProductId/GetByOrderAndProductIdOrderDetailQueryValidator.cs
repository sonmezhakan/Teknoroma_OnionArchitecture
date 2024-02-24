using FluentValidation;

namespace Teknoroma.Application.Features.OrderDetails.Queries.GetByOrderAndProductId
{
	public class GetByOrderAndProductIdOrderDetailQueryValidator:AbstractValidator<GetByOrderAndProductIdOrderDetailQueryRequest>
	{
        public GetByOrderAndProductIdOrderDetailQueryValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("");

            RuleFor(x => x.OrderId).NotEmpty().WithMessage("");
        }
    }
}
