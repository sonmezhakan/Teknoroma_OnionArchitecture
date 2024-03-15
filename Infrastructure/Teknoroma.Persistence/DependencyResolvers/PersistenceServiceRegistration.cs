using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;
using Teknoroma.Infrastructure.WebApiService;
using Teknoroma.Persistence.Context;
using Teknoroma.Persistence.Repositories;

namespace Teknoroma.Persistence.DependencyResolvers
{
    public static class PersistenceServiceRegistration
	{
		public static IServiceCollection AddPersistenceServiceRegistration(this IServiceCollection services)
		{
			ServiceProvider provider = services.BuildServiceProvider();

			var configuration = provider.GetService<IConfiguration>();

			//Context Service

			services.AddDbContext<TeknoromaContext>(options =>
			{
				options.UseLazyLoadingProxies();
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
			});


			//Repository Service
			services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
			services.AddScoped<IBranchRepository, BranchRepository>();
			services.AddScoped<IStockRepository, StockRepository>();
			services.AddScoped<IBrandRepository, BrandRepository>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<ICustomerRepository, CustomerRepository>();
			services.AddScoped<IEmployeeRepository, EmployeeRepository>();
			services.AddScoped<IOrderRepository, OrderRepository>();
			services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<ISupplierRepository, SupplierRepository>();
			services.AddScoped<IDepartmentRepository, DepartmentRepository>();
			services.AddScoped<IStockInputRepository, StockInputRepository>();
			services.AddScoped<IAppUserProfileRepository,  AppUserProfileRepository>();
			services.AddScoped<ITechnicalProblemRepository, TechnicalProblemRepository>();

			//Identity Service
			services.AddIdentity<AppUser, AppUserRole>().AddEntityFrameworkStores<TeknoromaContext>().AddDefaultTokenProviders();
			services.AddScoped<UserManager<AppUser>>();
			services.AddScoped<SignInManager<AppUser>>();

            return services;
		}
	}
}
