using MediatR;

namespace Teknoroma.Application.Features.Expenses.Queries.GetList
{
	public class GetAllExpenseQueryRequest:IRequest<List<GetAllExpenseQueryResponse>>
	{
	}
}
