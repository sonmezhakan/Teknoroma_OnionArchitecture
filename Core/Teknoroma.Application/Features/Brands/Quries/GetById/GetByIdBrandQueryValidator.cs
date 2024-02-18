using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Features.Brands.Contants;

namespace Teknoroma.Application.Features.Brands.Quries.GetById
{
	public class GetByIdBrandQueryValidator:AbstractValidator<GetByIdBrandQueryRequest>
	{
        public GetByIdBrandQueryValidator()
        {
			RuleFor(x => x.ID).NotEmpty().WithMessage(BrandsMessages.IDNotNull);
		}
    }
}
