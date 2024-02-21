using MediatR;

namespace Teknoroma.Application.Features.Employees.Queries.GetById
{
    public class GetByIdEmployeeQueryRequest : IRequest<GetByIdEmployeeQueryResponse>
    {
        public Guid ID { get; set; }
    }
}
