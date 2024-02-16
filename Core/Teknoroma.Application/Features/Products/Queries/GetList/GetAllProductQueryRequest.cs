using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Products.Queries.GetList
{
	public class GetAllProductQueryRequest:IRequest<List<GetAllProductQueryResponse>>
	{
	}
}
