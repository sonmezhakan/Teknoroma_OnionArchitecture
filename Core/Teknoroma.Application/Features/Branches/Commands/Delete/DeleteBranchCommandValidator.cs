using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Features.Branches.Constants;

namespace Teknoroma.Application.Features.Branches.Command.Delete
{
	public class DeleteBranchCommandValidator:AbstractValidator<DeleteBranchCommandRequest>
	{
        public DeleteBranchCommandValidator()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage(BranchesMessages.IDNotNull);
        }
    }
}
