using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

using Teknoroma.Persistence.Context;

namespace Teknoroma.Persistence.Repositories
{
    public class OrderDetailRepository : BaseRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(TeknoromaContext context) : base(context)
        {
        }
    }
}
