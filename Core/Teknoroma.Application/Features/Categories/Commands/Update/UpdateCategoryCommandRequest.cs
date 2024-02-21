using MediatR;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.Categories.Commands.Update
{
	public class UpdateCategoryCommandRequest:IRequest<Unit>, ITransactionalRequest
	{
        public Guid ID { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
