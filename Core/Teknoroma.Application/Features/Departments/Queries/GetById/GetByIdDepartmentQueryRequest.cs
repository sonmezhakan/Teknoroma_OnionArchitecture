using MediatR;

namespace Teknoroma.Application.Features.Departments.Queries.GetById
{
	public class GetByIdDepartmentQueryRequest:IRequest<GetByIdDepartmentQueryResponse>
	{
        public Guid ID { get; set; }
    }
}
