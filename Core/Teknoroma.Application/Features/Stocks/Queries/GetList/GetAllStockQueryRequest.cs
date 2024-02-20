﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Stocks.Queries.GetList
{
    public class GetAllStockQueryRequest : IRequest<List<GetAllStockQueryResponse>>
    {
        public Guid? ID { get; set; }
    }

}
