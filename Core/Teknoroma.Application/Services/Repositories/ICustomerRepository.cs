using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Services.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<IQueryable<Customer>> GetAllSelectIdAndNameAsync();
		Task<IQueryable<Customer>> GetAllSelectIdAndPhoneNumberAsync();
	}
}
