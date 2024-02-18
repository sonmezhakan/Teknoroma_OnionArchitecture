using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Suppliers.Queries.GetList
{
	public class GetAllSupplierQueryRequest:IRequest<List<GetAllSupplierQueryResponse>>
	{
	}
}
