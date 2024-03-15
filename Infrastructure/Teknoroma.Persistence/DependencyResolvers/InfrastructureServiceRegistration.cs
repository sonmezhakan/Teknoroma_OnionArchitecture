using Microsoft.Extensions.DependencyInjection;
using Teknoroma.Infrastructure.WebApiService;

namespace Teknoroma.Persistence.DependencyResolvers
{
	public static class InfrastructureServiceRegistration
	{
		public static IServiceCollection AddInfrastructureServiceRegistration(this IServiceCollection services)
		{

			//WebApi Service
			services.AddHttpClient();
			services.AddScoped<IApiService, ApiService>();

			return services;
		}
	}
}
