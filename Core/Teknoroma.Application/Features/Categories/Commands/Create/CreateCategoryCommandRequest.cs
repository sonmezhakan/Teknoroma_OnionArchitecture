using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Categories.Commands.Create
{
    public class CreateCategoryCommandRequest:IRequest<string>
    {
        public string CategoryName { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
    }
}
