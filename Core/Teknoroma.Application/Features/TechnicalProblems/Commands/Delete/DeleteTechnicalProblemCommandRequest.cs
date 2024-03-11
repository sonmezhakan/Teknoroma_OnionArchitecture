using MediatR;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.TechnicalProblems.Commands.Delete
{
    public class DeleteTechnicalProblemCommandRequest:IRequest<Unit>, ITransactionalRequest
	{
        public Guid ID { get; set; }

    }
}
