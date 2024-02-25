using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.Branches.Command.Create
{
	public class CreateBranchCommandRequest:IRequest<Unit>, ITransactionalRequest
	{
		public string BranchName { get; set; }
		public string? Address { get; set; }
		public string? PhoneNumber { get; set; }
		public string? Description { get; set; }
	}
}
