using MediatR;

namespace Teknoroma.Application.Features.Expenses.Queries.GetById
{
	public class GetByIdExpenseQueryRequest:IRequest<GetByIdExpenseQueryResponse>
	{
        public Guid ID { get; set; }
    }
}
