using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Categories.Commands.Update
{
    public class UpdateCategoryCommandRequest:IRequest<Unit>
    {
        public Guid ID { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
