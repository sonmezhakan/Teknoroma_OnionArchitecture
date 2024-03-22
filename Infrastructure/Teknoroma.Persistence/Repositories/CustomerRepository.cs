using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;
using Teknoroma.Persistence.Context;

namespace Teknoroma.Persistence.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly TeknoromaContext _context;

        public CustomerRepository(TeknoromaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IQueryable<Customer>> GetAllSelectIdAndNameAsync()
        {
            IQueryable<Customer> query = _context.Customers.Where(x => x.IsActive).Select(x => new Customer
            {
                ID = x.ID,
                FullName = x.FullName
            });
            return query;
        }
		public async Task<IQueryable<Customer>> GetAllSelectIdAndPhoneNumberAsync()
		{
			IQueryable<Customer> query = _context.Customers.Where(x => x.IsActive).Select(x => new Customer
			{
				ID = x.ID,
				PhoneNumber = x.PhoneNumber
			});
			return query;
		}
	}
}
