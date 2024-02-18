using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Categories.Commands.Delete
{
    public class DeleteCategoryCommandRequest:IRequest<Unit>
    {
        public Guid ID { get; set; }
    }
}
