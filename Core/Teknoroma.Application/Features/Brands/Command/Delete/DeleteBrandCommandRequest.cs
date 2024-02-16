using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Brands.Command.Delete
{
	public class DeleteBrandCommandRequest:IRequest<string>
	{
        public Guid ID { get; set; }
    }
}
