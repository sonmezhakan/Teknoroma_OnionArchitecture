using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Persistence.DependencyResolvers
{
	public static class MapperServiceRegistration
	{
		public static IServiceCollection AddAutoMapperServiceRegistration(this IServiceCollection services)
		{
			//AutoMapper Profile Service
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			return services;
		}
	}
}
