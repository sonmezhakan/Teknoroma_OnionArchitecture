using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;
using Teknoroma.Persistence.Context;

namespace Teknoroma.Persistence.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(TeknoromaContext context) : base(context)
        {
        }
    }
}
