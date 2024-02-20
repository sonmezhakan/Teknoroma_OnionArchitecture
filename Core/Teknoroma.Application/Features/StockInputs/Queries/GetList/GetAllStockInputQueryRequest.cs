using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.StockInputs.Queries.GetList
{
    public class GetAllStockInputQueryRequest:IRequest<List<GetAllStockInputQueryResponse>>
    {
    }
}
