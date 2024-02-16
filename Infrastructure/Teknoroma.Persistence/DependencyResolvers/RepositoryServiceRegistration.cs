using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;
using Teknoroma.Infrastructure.WebApiService;
using Teknoroma.Persistence.Context;
using Teknoroma.Persistence.Repositories;

namespace Teknoroma.Persistence.DependencyResolvers
{
	public static class RepositoryServiceRegistration
	{
		public static IServiceCollection AddRegisterServiceRegistration(this IServiceCollection services)
		{
			//Identity Service
			services.AddIdentity<AppUser, AppUserRole>().AddEntityFrameworkStores<TeknoromaContext>().AddDefaultTokenProviders();
			services.AddScoped<UserManager<AppUser>>();
			services.AddScoped<SignInManager<AppUser>>();

			//WebApi Service
			services.AddHttpClient();
			services.AddScoped<IApiService, ApiService>();



			//Repository Service
			services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

			services.AddScoped<IBranchRepository, BranchRepository>();

			services.AddScoped<IBranchProductRepository, BranchProductRepository>();

			services.AddScoped<IBrandRepository, BrandRepository>();

			services.AddScoped<ICategoryRepository, CategoryRepository>();

			services.AddScoped<ICustomerRepository, CustomerRepository>();

			services.AddScoped<IEmployeeRepository, EmployeeRepository>();

			services.AddScoped<IEmployeeDepartmentRepository, EmployeeDepartmentRepository>();

			services.AddScoped<IOrderRepository, OrderRepository>();

			services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();

			services.AddScoped<IProductRepository, ProductRepository>();

			services.AddScoped<ISupplierRepository, SupplierRepository>();

			services.AddScoped<IDepartmentRepository, DepartmentRepository>();

			return services;
		}
	}
}
