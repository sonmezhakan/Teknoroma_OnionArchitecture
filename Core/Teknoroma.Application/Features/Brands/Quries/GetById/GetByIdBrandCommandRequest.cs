using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Brands.Quries.GetById
{
	public class GetByIdBrandCommandRequest:IRequest<GetByIdBrandCommandResponse>
	{
        public Guid ID { get; set; }
    }
}
