using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Customers.Command.Delete
{
	public class DeleteCustomerCommandRequest:IRequest<string>
	{
        public Guid ID { get; set; }
    }
}
