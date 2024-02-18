using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Categories.Queries.GetById
{
    public class GetByIdCategoryQueryResponse
    {
        public Guid ID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
