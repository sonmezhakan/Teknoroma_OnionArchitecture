using MediatR;

namespace Teknoroma.Application.Features.TechnicalProblems.Commands.Delete
{
    public class DeleteTechnicalProblemCommandRequest:IRequest<Unit>
    {
        public Guid ID { get; set; }

    }
}
