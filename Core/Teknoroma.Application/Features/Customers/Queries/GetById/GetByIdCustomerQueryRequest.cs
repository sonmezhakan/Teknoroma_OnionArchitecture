using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Customers.Queries.GetById
{
	public class GetByIdCustomerQueryRequest:IRequest<GetByIdCustomerQueryResponse>
	{
        public Guid ID { get; set; }
    }
}
