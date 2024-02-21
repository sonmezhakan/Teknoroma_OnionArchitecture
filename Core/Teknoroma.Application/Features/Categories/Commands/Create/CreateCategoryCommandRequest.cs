using MediatR;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.Categories.Commands.Create
{
	public class CreateCategoryCommandRequest:IRequest<Unit>, ITransactionalRequest
	{
        public string CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
