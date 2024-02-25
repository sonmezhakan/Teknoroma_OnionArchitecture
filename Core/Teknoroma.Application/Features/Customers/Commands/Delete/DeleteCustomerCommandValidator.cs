using FluentValidation;
using Teknoroma.Application.Features.Customers.Contants;

namespace Teknoroma.Application.Features.Customers.Command.Delete
{
	public class DeleteCustomerCommandValidator:AbstractValidator<DeleteCustomerCommandRequest>
	{
        public DeleteCustomerCommandValidator()
        {
            RuleFor(x=>x.ID).NotEmpty().WithMessage(CustomersMessages.IDNotNull);
        }
    }
}
