using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Products.Command.Delete
{
	public class DeleteProductCommandRequest:IRequest<string>
	{
        public Guid ID { get; set; }
    }
}
