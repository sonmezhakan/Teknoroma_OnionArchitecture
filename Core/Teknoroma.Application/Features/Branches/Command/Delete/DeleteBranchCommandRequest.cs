using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Branches.Command.Delete
{
	public class DeleteBranchCommandRequest:IRequest<string>
	{
        public Guid ID { get; set; }
    }
}
