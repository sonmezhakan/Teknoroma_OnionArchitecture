using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Teknoroma.Persistence.Context;

namespace Teknoroma.Persistence.DependencyResolvers
{
	public static class DbContextServiceRegistration
	{
		public static IServiceCollection AddDbContextServiceRegistration(this IServiceCollection services)
		{
			ServiceProvider provider = services.BuildServiceProvider();

			var configuration = provider.GetService<IConfiguration>();

			//Context Service

			services.AddDbContext<TeknoromaContext>(options =>
			{
				options.UseLazyLoadingProxies();
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));


			});

			return services;
		}
	}
}
