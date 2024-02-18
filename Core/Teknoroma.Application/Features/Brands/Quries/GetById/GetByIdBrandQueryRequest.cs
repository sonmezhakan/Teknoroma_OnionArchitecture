using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Brands.Quries.GetById
{
	public class GetByIdBrandQueryRequest:IRequest<GetByIdBrandQueryResponse>
	{
        public Guid ID { get; set; }
    }
}
