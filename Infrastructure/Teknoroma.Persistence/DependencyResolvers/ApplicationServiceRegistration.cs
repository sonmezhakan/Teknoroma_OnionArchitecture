using FluentValidation;
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
using Teknoroma.Application.Features.Products.Rules;
using Teknoroma.Application.Features.Suppliers.Rules;
using Teknoroma.Application.Pipelines.Transaction;
using Teknoroma.Application.Pipelines.Validation;

namespace Teknoroma.Persistence.DependencyResolvers
{
	public static class ApplicationServiceRegistration
	{
		public static IServiceCollection AddAplicationServiceRegistration(this IServiceCollection services)
		{
			//AutoMapper Profile Service
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

			//MediatR Service
			services.AddMediatR(configuration =>
			{
				configuration.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
				configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
				configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
			});

			//services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

			//BusinessRules Service
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
			
			

			return services;
		}
	}
}
