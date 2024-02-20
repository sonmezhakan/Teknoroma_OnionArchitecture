﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Stocks.Command.Delete
{
    public class DeleteStockCommandRequest : IRequest<Unit>
    {
        public int MyProperty { get; set; }
    }
}
