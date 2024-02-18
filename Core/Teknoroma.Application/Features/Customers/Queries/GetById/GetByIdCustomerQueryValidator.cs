using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Features.Customers.Contants;

namespace Teknoroma.Application.Features.Customers.Queries.GetById
{
	public class GetByIdCustomerQueryValidator:AbstractValidator<GetByIdCustomerQueryRequest>
	{
		public GetByIdCustomerQueryValidator()
		{
			RuleFor(x => x.ID).NotEmpty().WithMessage(CustomersMessages.IDNotNull);
		}
	}
}
