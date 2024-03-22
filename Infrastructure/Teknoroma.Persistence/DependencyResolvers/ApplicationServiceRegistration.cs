using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Teknoroma.Application.Features.AppUserProfiles.Rules;
using Teknoroma.Application.Features.AppUserRoles.Rules;
using Teknoroma.Application.Features.AppUsers.Rules;
using Teknoroma.Application.Features.Branches.Rules;
using Teknoroma.Application.Features.Brands.Rules;
using Teknoroma.Application.Features.Categories.Rules;
using Teknoroma.Application.Features.Customers.Rules;
using Teknoroma.Application.Features.Departments.Rules;
using Teknoroma.Application.Features.Employees.Rules;
using Teknoroma.Application.Features.OrderDetails.Rules;
using Teknoroma.Application.Features.Orders.Rules;
using Teknoroma.Application.Features.Products.Rules;
using Teknoroma.Application.Features.Suppliers.Rules;
using Teknoroma.Application.Pipelines.Transaction;
using Teknoroma.Application.Pipelines.Validation;
using Teknoroma.Application.Security.JWTHelpers;
using Teknoroma.Application.Services.EmailServices;
using Teknoroma.Application.Services.WebApiServices;

namespace Teknoroma.Persistence.DependencyResolvers
{
	public static class ApplicationServiceRegistration
	{
		public static IServiceCollection AddAplicationServiceRegistration(this IServiceCollection services)
		{
            ServiceProvider provider = services.BuildServiceProvider();

            var configuration = provider.GetService<IConfiguration>();

            //WebApi Service
            services.AddHttpClient();
            services.AddScoped<IApiService, ApiService>();

            //AutoMapper Profile Service
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			//FluentValidation Service
			services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

			//JWT Service
			services.AddScoped<IJwtService, JwtService>();

			//Mail Service
			services.AddTransient<IMailService, MailService>();

			//MediatR Service
			services.AddMediatR(configuration =>
			{
				configuration.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
				configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
				configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
			});

			//BusinessRules
			services.AddTransient<BrandBusinessRules>();
			services.AddTransient<BranchBusinessRules>();
			services.AddTransient<CategoryBusinessRules>();
			services.AddTransient<CustomerBusinessRules>();
			services.AddTransient<DepartmentBusinessRules>();
			services.AddTransient<ProductBusinessRules>();
			services.AddTransient<SupplierBusinessRules>();
			services.AddTransient<AppUserProfileBusinessRules>();
			services.AddTransient<AppUserBusinessRules>();
			services.AddTransient<AppUserRoleBusinessRules>();
			services.AddTransient<EmployeeBusinessRules>();
			services.AddTransient<OrderBusinessRules>();
			services.AddTransient<OrderDetailBusinessRules>();

            return services;
		}
	}
}
