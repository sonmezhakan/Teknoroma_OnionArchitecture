using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Suppliers.Command.Delete
{
	public class DeleteSupplierCommandRequest:IRequest<Unit>
	{
        public Guid ID { get; set; }
    }
}
