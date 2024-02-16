using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Categories.Queries.GetById
{
    public class GetByIdCategoryQueryRequest:IRequest<GetByIdCategoryQueryResponse>
    {
        public Guid ID { get; set; }
    }
}
