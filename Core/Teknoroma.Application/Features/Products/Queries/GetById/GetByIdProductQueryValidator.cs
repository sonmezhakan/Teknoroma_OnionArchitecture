using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Features.Products.Constants;

namespace Teknoroma.Application.Features.Products.Queries.GetById
{
	public class GetByIdProductQueryValidator:AbstractValidator<GetByIdProductQueryRequest>
	{
        public GetByIdProductQueryValidator()
        {
			RuleFor(x => x.ID).NotEmpty().WithMessage(ProductsMessages.IDNotNull);
		}
    }
}
