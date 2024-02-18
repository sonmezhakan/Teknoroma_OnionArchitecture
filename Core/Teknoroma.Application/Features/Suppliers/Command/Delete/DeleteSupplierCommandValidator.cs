using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Features.Suppliers.Contants;

namespace Teknoroma.Application.Features.Suppliers.Command.Delete
{
	public class DeleteSupplierCommandValidator:AbstractValidator<DeleteSupplierCommandRequest>
	{
        public DeleteSupplierCommandValidator()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage(SuppliersMessages.IDNotNull);
        }
    }
}
