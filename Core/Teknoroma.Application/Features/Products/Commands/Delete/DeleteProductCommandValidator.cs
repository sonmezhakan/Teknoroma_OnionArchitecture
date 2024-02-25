using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Features.Products.Constants;

namespace Teknoroma.Application.Features.Products.Command.Delete
{
	public class DeleteProductCommandValidator:AbstractValidator<DeleteProductCommandRequest>
	{
        public DeleteProductCommandValidator()
        {
            RuleFor(x=>x.ID).NotEmpty().WithMessage(ProductsMessages.IDNotNull);
        }
    }
}
