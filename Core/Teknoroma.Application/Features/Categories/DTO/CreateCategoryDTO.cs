using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Categories.DTO
{
    public class CreateCategoryDTO
    {
        public string CategoryName { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
    }
}
